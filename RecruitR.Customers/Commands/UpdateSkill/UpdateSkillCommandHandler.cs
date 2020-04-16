using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand>
    {
        private readonly ICustomersRepository _repository;

        public UpdateSkillCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId);

            customer.ChangeSkill(request.Id, request.Experience, request.Name, request.Proficiency);

            _repository.Update(customer);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}