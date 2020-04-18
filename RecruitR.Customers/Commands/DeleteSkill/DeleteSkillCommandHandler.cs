using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand>
    {
        private readonly ICustomersRepository _repository;

        public DeleteSkillCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId);

            customer.RemoveSkill(request.Id);

            _repository.Update(customer);
            await _repository.SaveChanges();

            return  Unit.Value;
        }     
    }
}