using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Customers.Commands.DeleteCustomer;
using RecruitR.Customers.Commands.RegisterCustomer;
using RecruitR.Customers.Commands.UpdateCustomer;
using RecruitR.Customers.Dtos;
using RecruitR.Customers.Queries.GetBasicInfoCustomer;
using RecruitR.Customers.Queries.GetBasicInfoCustomers;

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
        public async Task CreateCustomer([FromBody] RegisterCustomerRequest request)
            => await _mediator.Send(new RegisterCustomerCommand(request.Id, request.FirstName, request.LastName, request.BirthDate, request.Email, request.Phone));

        [HttpDelete("{id}")]
        public async Task DeleteCustomer([FromRoute] Guid id)
            => await _mediator.Send(new DeleteCustomerCommand(id));

        [HttpPut("{id}")]
        public async Task UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request)
            => await _mediator.Send(new UpdateCustomerCommand(id, request.FirstName, request.LastName, request.BirthDate, request.Email, request.Phone));

        [HttpGet("{id}")]
        public async Task<BasicInfoCustomerDto> GetCustomerBasicInfo([FromRoute] Guid id)
            => await _mediator.Send(new GetBasicInfoCustomerQuery(id));

        [HttpGet]
        public async Task<IEnumerable<BasicInfoCustomerDto>> GetCustomersBasicInfo()
            => await _mediator.Send(new GetBasicInfoCustomersQuery());

    }
}