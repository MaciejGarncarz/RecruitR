using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Commands.RegisterCustomer
{
    public class RegisterCustomerCommand : ICommand
    {
        // TODO make example
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone  { get; set; }

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