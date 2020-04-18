using System;
using System.Collections.Generic;
using RecruitR.Domain.Projects.ValueObjects;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Projects
{
    public class Project : Entity, IAggregateRoot
    {
        public ProjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsRecruiting { get; private set; }
        public string Category { get; private set; }
        public string Type { get; private set; }

        public IReadOnlyCollection<Technology> Technologies => _technologies;
        public IReadOnlyCollection<Link> Links => _links;

        private HashSet<Technology> _technologies;
        private HashSet<Link> _links;

        public Project()
        {
            
        }

        public Project(Guid id, string description, bool isRecruiting, string category, string type, string name)
        {
            Id = new ProjectId(id);
            Description = description;
            IsRecruiting = isRecruiting;
            Category = category;
            Type = type;
            Name = name;
            _technologies = new HashSet<Technology>();
            _links = new HashSet<Link>();
        }

        private Project(
            Guid id,
            string description,
            bool isRecruiting,
            string category,
            string type,
            string name,
            HashSet<Technology> technologies,
            HashSet<Link> links
            )
        {
            Guard.AgainstEmptyIdentity(id);

            Id = new ProjectId(id);
            Description = description;
            IsRecruiting = isRecruiting;
            Category = category;
            Type = type;
            Name = name;
            _technologies = technologies;
            _links = links;
        }

        public static Project CreateProject(
            Guid id,
            string description,
            bool isRecruiting,
            string category,
            string type,
            string name,
            HashSet<Technology> technologies,
            HashSet<Link> links
            )
        {
            return new Project(id, description, isRecruiting, category, type, name, technologies, links);
        }

        public void ChangeName(string name)
        {
            Guard.AgainstEmptyString(name, nameof(name));
            Name = name;
        }

        public void ChangeDescription(string description)
        {
            Guard.AgainstEmptyString(description, nameof(description));
            Description = description;
        }

        public void ChangeCategory(string category)
        {
            Guard.AgainstEmptyString(category, nameof(category));
            Category = category;
        }

        public void ChangeType(string type)
        {
            Guard.AgainstEmptyString(type, nameof(type));
            Type = type;
        }

        public void AddLink(Link link)
        {
            Guard.AgainstNull(link, nameof(link));
            this._links.Add(link);
        }

        public void AddTechnology(Technology technology)
        {
            Guard.AgainstNull(technology, nameof(technology));
            this._technologies.Add(technology);
        }
    }
}