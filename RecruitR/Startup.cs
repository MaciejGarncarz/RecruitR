using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitR.Customers.Commands.RegisterCustomer;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(GetProjectQuery));
            services.AddMediatR(typeof(RegisterCustomerCommand));
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
            });
        }
    }
}
