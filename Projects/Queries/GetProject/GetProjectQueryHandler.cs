using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Domain.Projects;
using RecruitR.Persistence.Repositories.Projects;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IProjectsRepository _repository;
        public GetProjectQueryHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            // User dapper instead
            return new ProjectDto("Hello");
        }
    }
}