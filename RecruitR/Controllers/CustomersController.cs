using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Customers.Commands.RegisterCustomer;

namespace RecruitR.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateCustomer(RegisterCustomerCommand command)
            => await _mediator.Send(command);
    }
}