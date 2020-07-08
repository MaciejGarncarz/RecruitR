using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.Vacancy.AddVacancy
{
    public class AddVacancyCommandHandler : IRequestHandler<AddVacancyCommand>
    {
        private readonly IProjectsRepository _repository;

        public AddVacancyCommandHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddVacancyCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Get(request.ProjectId);

            if (project is null)
                throw new EntityNotFoundException(nameof(project));

            project.AddVacancy(new Domain.Projects.Entities.Vacancy(request.Id, request.Name, request.Description, request.Status, request.ExpirationDate));

            _repository.Update(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}