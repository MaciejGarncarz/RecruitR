using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Customers.Dtos;
using RecruitR.Persistence.ConnectionFactory;

namespace RecruitR.Customers.Queries.GetBasicInfoCustomers
{
    public class GetBasicInfoCustomersQueryHandler : IRequestHandler<GetBasicInfoCustomersQuery, IEnumerable<BasicInfoCustomerDto>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetBasicInfoCustomersQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<BasicInfoCustomerDto>> Handle(GetBasicInfoCustomersQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sql = @"
            SELECT 
	            ""Id"", 
                ""FirstName"", 
                ""LastName"", 
                ""BirthDate"", 
                ""Email"", 
                ""Phone""
            FROM public.""Customers"";";

            var customers = await connection.QueryAsync<BasicInfoCustomerDto>(sql);
            return customers;
        }
    }
}