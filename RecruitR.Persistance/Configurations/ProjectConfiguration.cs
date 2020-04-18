using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitR.Domain.Projects;
using RecruitR.Domain.Projects.ValueObjects;

namespace RecruitR.Persistence.Configurations
{
    public class ProjectsConfiguration : IEntityTypeConfiguration<Project>
    {
        internal const string Links = "_links";
        internal const string Technologies = "_technologies";

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, x => new ProjectId(x));

            builder.OwnsMany<Technology>(Technologies, y =>
            {
                y.WithOwner().HasForeignKey("ProjectId");

                y.Property<Guid>("Id");
                y.HasKey("Id");
            });

            builder.OwnsMany<Link>(Links, z =>
            {
                z.WithOwner().HasForeignKey("ProjectId");
                z.Property<Guid>("Id");
                z.HasKey("Id");
            });
        }
    }
}