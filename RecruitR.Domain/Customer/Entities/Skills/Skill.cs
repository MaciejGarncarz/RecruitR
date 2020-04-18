using System;
using RecruitR.Infrastructure.Domain;
using RecruitR.Infrastructure.Exceptions;

namespace RecruitR.Domain.Customer.Entities.Skills
{
    public class Skill : Entity
    {
        public SkillId Id { get; }
        public string Name { get; private set; }
        public uint Proficiency { get; private set; }
        public decimal Experience { get; private set; }

        public Skill()
        {
            
        }

        public Skill(Guid id, string name, uint proficiency, decimal experience)
        {
            Guard.AgainstEmptyIdentity(id);
            Guard.AgainstEmptyString(name, nameof(name));

            if(proficiency > 5)
                throw new DomainRuleViolation("Proficiency must be in range of 0 to 5");

            if(experience < 0 && experience > 10)
                throw new DomainRuleViolation("Experience must be in range of 0 to 10");

            Id = new SkillId(id);
            Name = name;
            Proficiency = proficiency;
            Experience = experience;
        }

        public void ChangeName(string name)
        {
            Guard.AgainstEmptyString(name, nameof(name));

            if (Name == name) return;

            Name = name;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Skill name has been changed"));
        }

        public void ChangeProficiency(uint proficiency)
        {
            if (proficiency > 5)
                throw new DomainRuleViolation("Proficiency must be in range of 0 to 5");

            if (Proficiency == proficiency) return;

            Proficiency = proficiency;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Skill proficiency has been changed"));
        }

        public void ChangeExperience(decimal experience)
        {
            if (experience < 0 && experience > 10)
                throw new DomainRuleViolation("Experience must be in range of 0 to 10");

            if (Experience == experience) return;

            Experience = experience;
            AddEvent(new PlaceholderDomainEvent(Guid.NewGuid(), DateTime.UtcNow, "Skill experience has been changed"));
        }



    }
}