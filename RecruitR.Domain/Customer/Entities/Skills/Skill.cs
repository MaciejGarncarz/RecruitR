using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Skills
{
    public class Skill : Entity
    {
        public SkillId Id { get; private set; }
        public string Name { get; set; }
        public uint Proficiency { get; private set; }
        public decimal Experience { get; private set; }
    }
}