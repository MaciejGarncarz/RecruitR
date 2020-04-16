using System;

namespace RecruitR.Customers.Commands.AddSkill
{
    public class AddSkillRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Proficiency { get; set; }
        public decimal Experience { get; set; }
    }
}