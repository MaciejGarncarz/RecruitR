using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Domain.Projects.ValueObjects;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectsRepository _repository;

        public UpdateProjectHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Get(request.Id);

            if (project is null)
                throw new EntityNotFound(nameof(project));

            project.ChangeName(request.Name);
            project.ChangeDescription(request.Description);
            project.SetRecruitingStatus(request.RecruitingStatus);
            project.UpdateProjectInformation(new ProjectInformation(request.Type, request.Category));

            _repository.Update(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}