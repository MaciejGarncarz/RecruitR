using Microsoft.EntityFrameworkCore;
using RecruitR.Domain.Customer;
using RecruitR.Domain.Projects;
using RecruitR.Persistence.Configurations;

namespace RecruitR.Persistence
{
    public class RecruitDbContext : DbContext
    {
        public RecruitDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}