using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Customers.Dtos;
using RecruitR.Persistence.ConnectionFactory;

namespace RecruitR.Customers.Queries.GetBasicInfoCustomer
{
    public class GetBasicInfoCustomerQueryHandler : IRequestHandler<GetBasicInfoCustomerQuery, BasicInfoCustomerDto>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetBasicInfoCustomerQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<BasicInfoCustomerDto> Handle(GetBasicInfoCustomerQuery request, CancellationToken cancellationToken)
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
            FROM public.""Customers""
            WHERE ""Id"" = @CustomerId;";

            var queryResult = await connection.QueryFirstOrDefaultAsync<BasicInfoCustomerDto>(sql, new { CustomerId = request.Id});

            return queryResult;
        }
    }
}