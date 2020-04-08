using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer
{
    public class CustomerId : IdentityBase
    {
        public CustomerId(Guid value) : base(value)
        {

        }
    }
}