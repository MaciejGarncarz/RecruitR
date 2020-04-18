using System;

namespace RecruitR.Customers.Dtos
{
    public class CustomerSkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Proficiency { get; set; }
        public decimal Experience { get; set; }
    }
}