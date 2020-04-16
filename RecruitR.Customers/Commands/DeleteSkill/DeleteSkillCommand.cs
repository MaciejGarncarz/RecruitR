using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Commands.DeleteSkill
{
    public class DeleteSkillCommand : ICommand
    {
        public Guid CustomerId { get; }
        public Guid Id { get; }

        public DeleteSkillCommand(Guid customerId, Guid id)
        {
            CustomerId = customerId;
            Id = id;
        }
    }
}