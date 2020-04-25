using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Persistence.ConnectionFactory;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IConnectionFactory _connectionFactory;

        public GetProjectsQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sql = @"
                   SELECT   id, 
                            name, 
                            description, 
                            ""recruitingStatus"",
                            type, 
                            category
                  FROM public.""Projects""";

            var projects = await connection.QueryAsync<ProjectDto>(sql);
            return projects;
        }
    }
}