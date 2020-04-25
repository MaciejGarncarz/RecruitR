using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitR.Domain.Projects;
using RecruitR.Domain.Projects.Entities;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Domain.Projects.ValueObjects;
using Type = RecruitR.Domain.Projects.Enums.Type;

namespace RecruitR.Persistence.Configurations
{
    public class ProjectsConfiguration : IEntityTypeConfiguration<Project>
    {
        internal const string Links = "_links";
        internal const string Technologies = "_technologies";
        internal const string Vacancies = "_vacancies";

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ProjectId(x))
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(1000);
            

            builder.Property(x => x.Description)
                .HasColumnName("category")
                .HasMaxLength(2000);

            builder.Property(x => x.RecruitingStatus)
                .HasColumnName("recruitingStatus");

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

            builder.OwnsOne(x => x.ProjectInformation, pi =>
            {
                pi.Property(y => y.Type)
                    .HasColumnName("type")
                    .HasConversion(new EnumToNumberConverter<Type, byte>());
                pi.Property(y => y.Category)
                    .HasColumnName("category")
                    .HasConversion(new EnumToNumberConverter<Category, byte>());
            });

            builder.OwnsMany<Vacancy>(Vacancies, v =>
            {
                v.WithOwner()
                    .HasForeignKey("ProjectId");

                v.HasKey(x => x.Id);

                v.Property(z => z.Id)
                    .HasColumnName("id")
                    .HasConversion(t => t.Value, u => new VacancyId(u));

                v.Property(x => x.Name)
                    .HasColumnName("name")
                    .HasMaxLength(1000);

                v.Property(x => x.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2000);

                v.Property(x => x.ExpirationDate)
                    .HasColumnName("expirationDate");

                v.Property(x => x.Status)
                    .HasColumnName("status");
            });
        }
    }
}