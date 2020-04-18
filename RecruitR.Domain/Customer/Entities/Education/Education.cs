using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Education
{
    public class Education : Entity
    {
        public EducationId Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? Finish { get; private set; }

        public Education()
        {

        }

        public Education(Guid id, string name, string description, DateTime start, DateTime? finish)
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(name, nameof(name));
            Guard.AgainstEmptyString(description, nameof(description));

            Id = new EducationId(id);
            Name = name;
            Description = description;
            Start = start;
            Finish = finish;
        }

        public void ChangeName(string name)
        {
            Guard.AgainstEmptyString(name, nameof(name));

            if (Name == name) return;

            Name = name;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Education name has been changed"));
        }

        public void ChangeDescription(string description)
        {
            Guard.AgainstEmptyString(description, nameof(description));

            if (Description == description) return;

            Description = description;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Education description has been changed"));
        }

        public void SetStartDate(DateTime start)
        {
            if (Start == start) return;

            Start = start;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Education start date has been changed"));
        }

        public void SetFinishDate(DateTime? finish)
        {
            if (Finish == finish) return;

            Finish = finish;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Education finish date has been changed"));
        }

    }
}