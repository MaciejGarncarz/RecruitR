using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Customers.Commands.AddSkill;
using RecruitR.Customers.Commands.DeleteSkill;
using RecruitR.Customers.Commands.UpdateSkill;
using RecruitR.Customers.Dtos;
using RecruitR.Customers.Queries.GetCustomerSkills;

namespace RecruitR.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersSkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersSkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{customerId}/skills")]
        public async Task AddSkill([FromRoute] Guid customerId, [FromBody] AddSkillRequest request)
            => await _mediator.Send(
                new AddSkillCommand(customerId, request.Id, request.Name, request.Proficiency, request.Experience)
                );

        [HttpDelete("{customerId}/skills/{id}")]
        public async Task DeleteSkill([FromRoute] Guid customerId, [FromRoute] Guid id)
            => await _mediator.Send(new DeleteSkillCommand(customerId, id));

        [HttpPut("{customerId}/skills/{id}")]
        public async Task UpdateSkill([FromRoute] Guid customerId, [FromRoute] Guid id, [FromBody] UpdateSkillRequest request)
            => await  _mediator.Send(
                new UpdateSkillCommand(customerId, id, request.Name, request.Proficiency, request.Experience)
                );

        [HttpGet("{customerId}/skills")]
        public async Task<IEnumerable<CustomerSkillDto>> GetCustomerSkills([FromRoute] Guid customerId)
            => await _mediator.Send(new GetCustomerSkillsQuery(customerId));


    }
}