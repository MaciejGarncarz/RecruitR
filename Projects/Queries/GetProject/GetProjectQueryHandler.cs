using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using RecruitR.Domain.Projects;
using RecruitR.Persistence.ConnectionFactory;
using RecruitR.Persistence.Repositories.Projects;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IConnectionFactory _connectionFactory;
        public GetProjectQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            const string sql = @"
                   SELECT   id, 
                            name, 
                            description, 
                            ""recruitingStatus"",
                            type, 
                            category
                  FROM public.""Projects""
                  WHERE id = @ProjectId";

            var project = await connection.QueryFirstOrDefaultAsync<ProjectDto>(sql, new {ProjectId = request.Id});
            return project;
        }
    }
}