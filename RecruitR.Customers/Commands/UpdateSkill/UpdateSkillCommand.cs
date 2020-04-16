using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Commands.UpdateSkill
{
    public class UpdateSkillCommand : ICommand
    {
        public Guid CustomerId { get; }
        public Guid Id { get; }
        public string Name { get; }
        public uint Proficiency { get; }
        public decimal Experience { get; }

        public UpdateSkillCommand(Guid customerId, Guid id, string name, uint proficiency, decimal experience)
        {
            CustomerId = customerId;
            Id = id;
            Name = name;
            Proficiency = proficiency;
            Experience = experience;
        }
    }
}