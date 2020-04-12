using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : ICommand
    {
        public Guid Id { get; }
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}