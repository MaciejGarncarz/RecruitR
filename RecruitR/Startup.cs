using System;
using Consul;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitR.API.Extensions;
using RecruitR.Customers.Commands.RegisterCustomer;
using RecruitR.Infrastructure.Config;
using RecruitR.Infrastructure.ExternalBus;
using RecruitR.Persistence;
using RecruitR.Persistence.ConnectionFactory;
using RecruitR.Persistence.Repositories.Customers;
using RecruitR.Persistence.Repositories.Projects;
using RecruitR.Projects.Queries.GetProject;

namespace RecruitR.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup), typeof(GetProjectQuery), typeof(RegisterCustomerCommand));
            services.AddMassTransit(x =>
            {
                x.AddConsumer<TestMessageConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("test-listener", e =>
                    {
                        e.ConfigureConsumer<TestMessageConsumer>(context);
                    });
                });
            });
            services.Configure<ConsulOptions>(Configuration.GetSection("consulOptions"));
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = Configuration["consulOptions:address"];
                consulConfig.Address = new Uri(address);
            }));
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();
            services.AddEntityFrameworkNpgsql().AddDbContext<RecruitDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("RecruitConnection")), ServiceLifetime.Transient);
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "RecruitR",
                    Version = "v1",
                    Description = "RecruitR API",
                });
            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(x => x.AddPolicy("Police", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseConsul(lifetime);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
            });
        }
    }
}
