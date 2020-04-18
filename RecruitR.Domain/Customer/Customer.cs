using System;
using System.Collections.Generic;
using System.Linq;
using RecruitR.Domain.Customer.Entities.Education;
using RecruitR.Domain.Customer.Entities.Experience;
using RecruitR.Domain.Customer.Entities.Skills;
using RecruitR.Domain.Customer.ValueObjects;
using RecruitR.Infrastructure.Domain;
using RecruitR.Infrastructure.Exceptions;

namespace RecruitR.Domain.Customer
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Education> Education => _education;
        public IReadOnlyCollection<Experience> Experiences => _experiences;
        public IReadOnlyCollection<Skill> Skills => _skills;
        //TODO Dunno about this it is probably value object
        //public HashSet<string> Links { get; private set; }
        public PersonalInfo Info { get; private set; }
        public bool Status { get; private set; }

        private HashSet<Education> _education { get; }
        private HashSet<Experience> _experiences { get; }
        private HashSet<Skill> _skills { get; }

        public Customer()
        {
            _education = new HashSet<Education>();
            _experiences = new HashSet<Experience>();
            _skills = new HashSet<Skill>();
        }

        private Customer(
            Guid id,
            string firstName,
            string lastName,
            DateTime birthDate,
            string email,
            string phone
            )
        {
            Id = new CustomerId(id);
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            Status = true;
        }

        public static Customer Register(
            Guid id,
            string firstName,
            string lastName,
            DateTime birthDate,
            string email,
            string phone
            )
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(firstName, nameof(firstName));
            Guard.AgainstEmptyString(lastName, nameof(lastName));
            Guard.AgainstEmptyString(email, nameof(email));
            Guard.AgainstEmptyString(phone, nameof(phone));

            return new Customer(id, firstName, lastName, birthDate, email, phone);
        }

        public void ChangeFirstName(string firstName)
        {
            Guard.AgainstEmptyString(firstName, nameof(firstName));

            if (FirstName == firstName) return;

            FirstName = firstName;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "First name has been changed"));
        }

        public void ChangeLastName(string lastName)
        {
            Guard.AgainstEmptyString(lastName, nameof(lastName));

            if (LastName == lastName) return;

            LastName = lastName;
            AddEvent(new PlaceholderDomainEvent(Guid.Empty, DateTime.UtcNow, "Last name has been changed"));
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
             var earliestDate = new DateTime(1940, 1, 1);
             var latestDate = new DateTime(2100, 1, 1);

             Guard.AgainstInvalidDateRange(earliestDate, latestDate, birthDate);
            
            if (BirthDate == birthDate) return;

            BirthDate = birthDate;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow,  "Birth date has been changed"));
        }

        public void ChangeEmail(string email)
        {
            // TODO Check some nuggets for email validation

            Guard.AgainstEmptyString(email, nameof(email));

            if (Email == email) return;

            Email = email;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow,  "Email has been changed"));
        }

        public void ChangePhone(string phone)
        {
            // TODO Check for phone validation and think about internalization

            Guard.AgainstEmptyString(phone, nameof(phone));

            if (Phone == phone) return;

            Phone = phone;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(),  DateTime.UtcNow, " Phone has been changed"));
        }

        public void ChangeStatus(bool status)
        {
            if (Status == status) return;

            Status = status;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Status has been changed"));
        }

        public void ChangePersonalInformation(PersonalInfo customerInformation)
        {
            Guard.AgainstNull(customerInformation, nameof(customerInformation));

            if(Info == customerInformation) return;

            Info = customerInformation;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Customer personal information has been changed"));
        }

        public void AddSkill(Skill skill)
        {
            Guard.AgainstNull(skill, nameof(skill));

            _skills.Add(skill);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Skill has been added"));
        }

        public void RemoveSkill(Guid skillId)
        {
            Guard.AgainstEmptyIdentity(skillId);

            var skillToRemove = _skills.SingleOrDefault(x => x.Id == new SkillId(skillId));
            
            // TODO Maybe entity not found exception ? To consider 
            if(skillToRemove is null)
                throw new DomainRuleViolation("Customer skill not found");

            _skills.Remove(skillToRemove);

            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Skill has been removed"));
        }

        public void ChangeSkill(Guid id, decimal experience, string name, uint proficiency)
        {
            Guard.AgainstEmptyIdentity(id);

            var skill = _skills.SingleOrDefault(x => x.Id == new SkillId(id));

            Guard.AgainstNull(skill, nameof(skill));

            skill.ChangeExperience(experience);
            skill.ChangeName(name);
            skill.ChangeProficiency(proficiency);
        }

        public void AddExperience(Experience experience)
        {
            Guard.AgainstNull(experience, nameof(experience));

            _experiences.Add(experience);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Experience has been added"));
        }

        public void RemoveExperience(Guid experienceId)
        {
            Guard.AgainstEmptyIdentity(experienceId);

            var experienceToRemove = _experiences.SingleOrDefault(x => x.Id == new ExperienceId(experienceId));

            if(experienceToRemove is null)
                throw new DomainRuleViolation("Customer experience not found");

            _experiences.Remove(experienceToRemove);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Customer experience has been removed"));
        }

        public void ChangeExperience(Guid experienceId, string name, string description, DateTime start, DateTime? finish)
        {
            Guard.AgainstEmptyIdentity(experienceId);

            var experience = _experiences.SingleOrDefault(x => x.Id == new ExperienceId(experienceId));

            Guard.AgainstNull(experience, nameof(experience));

            experience.ChangeName(name);
            experience.ChangeDescription(description);
            experience.SetStartDate(start);
            experience.SetFinishDate(finish);
        }

        public void AddEducation(Education education)
        {
            Guard.AgainstNull(education, nameof(education));

            _education.Add(education);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Education has been added"));
        }

        public void RemoveEducation(Guid educationId)
        {
            Guard.AgainstEmptyIdentity(educationId);

            var educationToRemove = _education.SingleOrDefault(x => x.Id == new EducationId(educationId));

            if (educationToRemove is null)
                throw new DomainRuleViolation("Customer experience not found");

            _education.Remove(educationToRemove);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Customer education has been removed"));
        }

        public void ChangeEducation(Guid educationId, string name, string description, DateTime start, DateTime? finish)
        {
            Guard.AgainstEmptyIdentity(educationId);

            var education = _education.SingleOrDefault(x => x.Id == new EducationId(educationId));

            Guard.AgainstNull(education, nameof(education));

            education.ChangeName(name);
            education.ChangeDescription(description);
            education.SetStartDate(start);
            education.SetFinishDate(finish);
        }
    }
}

//TODO
// This can be done when I have nothing else to do
//public string Photo { get; private set; }

// Status should be enum or even be in different service

// Events - V
// Entities check
// Value object checks - V
// Guards - V
// Write the domain methods - V
// Entity config - V
// Decide what to do with commands and their serialization
// Write the commands 
    // Basic crud customer commands - V
    // CRUD skills commands
    // CRUD experiences commands
    // CRUD education commands
// Write the queries with dapperinio
    // Basic crud customer queries
