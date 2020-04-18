using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecruitR.Infrastructure.Exceptions;
using RecruitR.Persistence.Repositories.Customers;

namespace RecruitR.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomersRepository _repository;

        public DeleteCustomerCommandHandler(ICustomersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.Id);   

            if(customer is null)
                throw new EntityNotFound(nameof(customer));

            _repository.Delete(customer);
            await _repository.SaveChanges();

            return Unit.Value;
        }
    }
}