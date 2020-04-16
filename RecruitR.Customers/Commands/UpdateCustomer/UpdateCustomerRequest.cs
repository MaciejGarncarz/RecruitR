using System;

namespace RecruitR.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}