using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Projects;

namespace RecruitR.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectsRepository _repository;

        public DeleteProjectCommandHandler(IProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Get(request.Id);

            if(project is null)
                throw new EntityNotFoundException(nameof(project));

            _repository.Delete(project);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}