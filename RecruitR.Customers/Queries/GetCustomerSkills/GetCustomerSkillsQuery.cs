using System;
using System.Collections.Generic;
using RecruitR.Customers.Dtos;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Queries.GetCustomerSkills
{
    public class GetCustomerSkillsQuery : IQuery<IEnumerable<CustomerSkillDto>>
    {
        public Guid CustomerId { get; }

        public GetCustomerSkillsQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}