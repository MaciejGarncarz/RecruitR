using System;
using System.Collections.Generic;
using RecruitR.Domain.Customer.Entities.Education;
using RecruitR.Domain.Customer.Entities.Experience;
using RecruitR.Domain.Customer.Entities.Skills;
using RecruitR.Domain.Customer.ValueObjects;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer
{
    public class Customer : Entity, IAggregate
    {
        public CustomerId Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyList<Education> Education => _education;
        public IReadOnlyList<Experience> Experiences => _experiences;
        public IReadOnlyList<Skill> Skills => _skills;
        public IList<string> Links { get; private set; }
        public PersonalInfo Info { get; private set; }
        public bool Status { get; private set; }

        private List<Education> _education { get; set; }
        private List<Experience> _experiences { get; set; }
        private List<Skill> _skills { get; set; }



    }
}

// This can be done when I have nothing else to do
//public string Photo { get; private set; }

// Status should be enum or even be in different service

// Events - V
// Entities check
// Value object checks - V
// Guards
// Write the domain methods !
// Entity config
// Write the commands !
// Write the queries with dapperinio :D
