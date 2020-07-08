using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.Vacancy.UpdateVacancy
{
    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand>
    {
        private readonly IProjectsRepository _repository;

        public UpdateVacancyCommandHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Get(request.ProjectId);

            if(project is null)
                throw new EntityNotFoundException(nameof(project));

            project.UpdateVacancy(request.Id, request.Name, request.Description, request.Status, request.ExpirationDate);

            _repository.Update(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}