using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomersRepository _repository;

        public UpdateCustomerCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.Id);

            if(customer is null)
                throw new EntityNotFoundException(nameof(customer));

            customer.ChangeFirstName(request.FirstName);
            customer.ChangeLastName(request.LastName);
            customer.ChangeEmail(request.Email);
            customer.ChangePhone(request.Phone);
            customer.ChangeBirthDate(request.BirthDate);

            _repository.Update(customer);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}