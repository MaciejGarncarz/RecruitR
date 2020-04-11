using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Experience
{
    public class Experience : Entity
    {
        public ExperienceId Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? Finish { get; private set; }

        public Experience()
        {
            
        }

        public Experience(Guid id, string name, string description, DateTime start, DateTime? finish)
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(name, nameof(name));
            Guard.AgainstEmptyString(description, nameof(description));

            Id = new ExperienceId(id);
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
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Experience name has been changed"));
        }

        public void ChangeDescription(string description)
        {
            Guard.AgainstEmptyString(description, nameof(description));

            if (Description == description) return;

            Description = description;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Experience description has been changed"));
        }

        public void SetStartDate(DateTime start)
        {
            if (Start == start) return;

            Start = start;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Start date has been changed"));
        }

        public void SetFinishDate(DateTime? finish)
        {
            if (Finish == finish) return;

            Finish = finish;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Finish date has been changed"));
        }
    }
}