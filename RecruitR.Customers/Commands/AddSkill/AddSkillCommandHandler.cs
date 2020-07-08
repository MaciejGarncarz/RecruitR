using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Domain.Customer.Entities.Skills;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.AddSkill
{
    public class AddSkillCommandHandler : IRequestHandler<AddSkillCommand>
    {
        private readonly ICustomersRepository _repository;

        public AddSkillCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId);

            if(customer is null)
                throw new EntityNotFoundException(nameof(customer));

            customer.AddSkill(new Skill(request.Id, request.Name, request.Proficiency, request.Experience));

            _repository.Update(customer);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}