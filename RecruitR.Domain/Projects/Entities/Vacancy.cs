using System;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Projects.Entities
{
    public class Vacancy : Entity
    {
        public VacancyId Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public VacancyStatus Status { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        //public int NumberOfSpots { get; private set; } //TODO 

        public Vacancy(Guid id, string name, string description, VacancyStatus status, DateTime expirationDate)
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(name, nameof(name));
            Guard.AgainstEmptyString(description, nameof(description));

            Id = new VacancyId(id);
            Name = name;
            Description = description;
            Status = status;
            ExpirationDate = expirationDate;
        }

        public void ChangeName(string name)
        {
            Guard.AgainstEmptyString(name, nameof(name));

            if (Name == name) return;

            Name = name;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Vacancy name has been changed"));
        }

        public void ChangeDescription(string description)
        {
            Guard.AgainstEmptyString(description, nameof(description));

            if (Description == description) return;

            Description = description;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(),  DateTime.UtcNow, "Vacancy description has been changed"));
        }

        public void ChangeStatus(VacancyStatus status)
        {
            if (Status == status) return;

            Status = status;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Vacancy status has been changed"));
        }

        public void ChangeExpirationDate(DateTime expirationDate)
        {
            // TODO some logic with changing date cannot be set to 2100 or something like that


            ExpirationDate = expirationDate;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Expiration date has been changed"));
            // TODO this event should change vacancy status
        }





    }
}