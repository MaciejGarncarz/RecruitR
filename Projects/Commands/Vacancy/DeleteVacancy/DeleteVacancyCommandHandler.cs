using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.Vacancy.DeleteVacancy
{
    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand>
    {
        private readonly IProjectsRepository _repository;

        public DeleteVacancyCommandHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Get(request.ProjectId);

            if(project is null)
                throw new EntityNotFoundException(nameof(project));

            project.RemoveVacancy(request.Id);

            _repository.Update(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}