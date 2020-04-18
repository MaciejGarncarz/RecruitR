using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitR.Domain.Customer;
using RecruitR.Domain.Customer.Entities.Education;
using RecruitR.Domain.Customer.Entities.Experience;
using RecruitR.Domain.Customer.Entities.Skills;
using RecruitR.Domain.Customer.ValueObjects;

namespace RecruitR.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        internal const string _skills = "_skills";
        internal const string _experiences = "_experiences";
        internal const string _education = "_education";

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, y => new CustomerId(y));

            builder.Property(x => x.FirstName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.OwnsOne(x => x.Info, personalInformation =>
            {
                personalInformation.Property(y => y.Description)
                    .HasMaxLength(2000);

                personalInformation.Property(y => y.Nationality)
                    .HasMaxLength(200);

                personalInformation.Property(y => y.Gender).HasConversion(new EnumToNumberConverter<Gender, byte>());
            });

            builder.OwnsMany<Skill>(_skills, y =>
            {
                y.WithOwner().HasForeignKey("CustomerId");
                y.HasKey(z => z.Id);
                y.Property(z => z.Id).HasConversion(t => t.Value, u => new SkillId(u));
            });

            builder.OwnsMany<Experience>(_experiences, y =>
            {
                y.WithOwner().HasForeignKey("CustomerId");
                y.HasKey(z => z.Id);
                y.Property(z => z.Id).HasConversion(t => t.Value, u => new ExperienceId(u));
            });

            builder.OwnsMany<Education>(_education, y =>
            {
                y.WithOwner().HasForeignKey("CustomerId");
                y.HasKey(z => z.Id);
                y.Property(z => z.Id).HasConversion(t => t.Value, u => new EducationId(u));
            });
        }
    }
}