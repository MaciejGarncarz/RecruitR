using System;
using System.Collections.Generic;
using System.Linq;
using RecruitR.Domain.Projects.Entities;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Domain.Projects.ValueObjects;
using RecruitR.Infrastructure.Domain;
using RecruitR.Infrastructure.Exceptions;

namespace RecruitR.Domain.Projects
{
    public class Project : Entity, IAggregateRoot
    {
        public ProjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool RecruitingStatus { get; private set; } // TODO maybe an enum also, something to think about
        //public string Members { get; set; } TODO ProjectCustomers with different permissions
        //public string Owner { get; set; } TODO This should be based on resource
        public ProjectInformation ProjectInformation { get; private set; }
        public IReadOnlyCollection<Technology> Technologies => _technologies;
        public IReadOnlyCollection<Link> Links => _links;
        public IReadOnlyCollection<Vacancy> Vacancies => _vacancies;

        private HashSet<Technology> _technologies;
        private HashSet<Link> _links;
        private HashSet<Vacancy> _vacancies;

        public Project()
        {
            _technologies = new HashSet<Technology>();
            _links = new HashSet<Link>();
            _vacancies = new HashSet<Vacancy>();
        }

        private Project(
            Guid id, 
            string name, 
            string description, 
            bool recruitingStatus, 
            Enums.Type type,
            Category category
            )
        {
            Id = new ProjectId(id);
            Name = name;
            Description = description;
            RecruitingStatus = recruitingStatus;
            ProjectInformation = new ProjectInformation(type, category);
        }

        public static Project CreateProject(
            Guid id,
            string description,
            bool recruitingStatus,
            string name,
            Enums.Type type, 
            Category category
            )
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(name, nameof(name));
            Guard.AgainstEmptyString(description, nameof(description));

            return new Project(id, name, description, recruitingStatus, type, category);
        }

        public void ChangeName(string name)
        {
            Guard.AgainstEmptyString(name, nameof(name));

            if (Name == name) return;
            
            Name = name;
            AddEvent(new PlaceholderDomainEvent( Guid.NewGuid(), DateTime.UtcNow, "Name has been changed"));
        }

        public void ChangeDescription(string description)
        {
            Guard.AgainstEmptyString(description, nameof(description));

            if (Description == description) return;

            Description = description;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.Now, "Description has been changed"));
        }

        public void SetRecruitingStatus(bool recruitingStatus)
        {
            if (RecruitingStatus == recruitingStatus) return;

            RecruitingStatus = recruitingStatus;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "RecruitingStatus has been changed"));
        }

        public void UpdateProjectInformation(ProjectInformation projectInformation)
        {
            Guard.AgainstNull(projectInformation, nameof(projectInformation));

            if (ProjectInformation == projectInformation) return;

            ProjectInformation = projectInformation;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Project information has been updated"));
        }

        public void AddVacancy(Vacancy vacancy)
        {
            Guard.AgainstNull(vacancy, nameof(vacancy));

            _vacancies.Add(vacancy);
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Vacancy has been added to project"));
        }

        public void RemoveVacancy(Guid vacancyId)
        {
            Guard.AgainstEmptyIdentity(vacancyId);

            var vacancy = _vacancies.SingleOrDefault(x => x.Id == new VacancyId(vacancyId));

            if(vacancy is null)
                throw new EntityNotFound(nameof(vacancy));

            _vacancies.Remove(vacancy);

            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Vacancy has been removed from project"));
        }

        public void UpdateVacancy(Guid id, string name, string description, VacancyStatus status, DateTime expirationDate)
        {
            var vacancy = _vacancies.SingleOrDefault(x => x.Id == new VacancyId(id));

            if(vacancy is null)
                throw new EntityNotFound(nameof(vacancy));

            vacancy.ChangeName(name);
            vacancy.ChangeDescription(description);
            vacancy.ChangeStatus(status);
            vacancy.ChangeExpirationDate(expirationDate);
            
        }
    }
}

// Create all basic projects properties and methods -V
// Projects entity configuration(with small Columns) -V
// Create vacancy entity, all methods and columns - V
// Vacancy entity configuration also with small columns - V
// Customer CRUD with dapper - V
// Vacancy CRUD with dapper - V

    // Think about ProjectsCustomers and maybe do it
// Make hangfire changes status with expiration date
// After 7 days with status closed vacancy should be permanently deleted
    