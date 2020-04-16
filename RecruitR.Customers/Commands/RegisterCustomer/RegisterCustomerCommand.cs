using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Commands.RegisterCustomer
{
    public class RegisterCustomerCommand : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public string Phone  { get; }

        public RegisterCustomerCommand(
            Guid id, 
            string firstName, 
            string lastName, 
            DateTime birthDate, 
            string email, 
            string phone
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
        }
    }
}