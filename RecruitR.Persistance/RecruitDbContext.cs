using Microsoft.EntityFrameworkCore;
using RecruitR.Domain.Projects;
using RecruitR.Persistence.Configurations.Projects;

namespace RecruitR.Persistence
{
    public class RecruitDbContext : DbContext
    {
        public RecruitDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}