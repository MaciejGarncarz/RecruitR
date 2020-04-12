using System;

namespace RecruitR.Customers.Queries.GetBasicInfoCustomer
{
    public class BasicInfoCustomerDto
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public string Phone { get; }

        public BasicInfoCustomerDto(Guid id, string firstName, string lastName, DateTime birthDate, string email, string phone)
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