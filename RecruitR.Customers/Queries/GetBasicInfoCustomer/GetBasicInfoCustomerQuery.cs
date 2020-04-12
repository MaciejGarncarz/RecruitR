using System;
using RecruitR.Infrastructure;

namespace RecruitR.Customers.Queries.GetBasicInfoCustomer
{
    public class GetBasicInfoCustomerQuery : IQuery<BasicInfoCustomerDto>
    {
        public Guid Id { get; }

        public GetBasicInfoCustomerQuery(Guid id)
        {
            Id = id;
        }
    }
}