using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Domain.Customer;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand>
    {
        private readonly ICustomersRepository _repository;

        public RegisterCustomerCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Register(
                request.Id, 
                request.FirstName, 
                request.LastName, 
                request.BirthDate,
                request.Email, 
                request.Phone
                );

            await _repository.Add(customer);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}