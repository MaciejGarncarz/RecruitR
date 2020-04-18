using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Customers.Dtos;
using RecruitR.Persistence.ConnectionFactory;

namespace RecruitR.Customers.Queries.GetCustomerSkills
{
    public class GetCustomerSkillQueryHandler : IRequestHandler<GetCustomerSkillsQuery, IEnumerable<CustomerSkillDto>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetCustomerSkillQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CustomerSkillDto>> Handle(GetCustomerSkillsQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();
            const string sql = @"
                     SELECT 
                        ""Id"", 
                        ""Name"", 
                        ""Proficiency"", 
                        ""Experience""
                     FROM public.""Skill""
                     WHERE ""CustomerId"" = @CustomerId";

            var customerSkills = await connection.QueryAsync<CustomerSkillDto>(sql, new { CustomerId = request.CustomerId});

            return customerSkills;
        }
    }
}