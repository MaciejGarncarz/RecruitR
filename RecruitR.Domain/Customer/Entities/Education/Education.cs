using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Education
{
    public class Education : Entity
    {
        public EducationId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? Finish { get; private set; }

    }
}