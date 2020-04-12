using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Customers.Commands.DeleteCustomer;
using RecruitR.Customers.Commands.RegisterCustomer;
using RecruitR.Customers.Commands.UpdateCustomer;
using RecruitR.Customers.Queries.GetBasicInfoCustomer;

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
        public async Task CreateCustomer([FromBody] RegisterCustomerCommand command)
            => await _mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task DeleteCustomer([FromRoute] Guid id)
            => await _mediator.Send(new DeleteCustomerCommand(id));

        [HttpPut]
        public async Task UpdateCustomer([FromBody] UpdateCustomerCommand command)
            => await _mediator.Send(command);

        [HttpGet("{id}")]
        public async Task<BasicInfoCustomerDto> GetCustomerBasicInfo([FromRoute] Guid id)
            => await _mediator.Send(new GetBasicInfoCustomerQuery(id));

    }
}