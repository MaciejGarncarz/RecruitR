using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Projects.Commands.CreateProject;
using RecruitR.Projects.Dtos;
using RecruitR.Projects.Queries.GetProject;

namespace RecruitR.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateProject()
            => await _mediator.Send(new CreateProjectCommand());

        [HttpGet("{id}")]
        public async Task<ProjectDto> GetProject([FromRoute] Guid id)
            => await _mediator.Send(new GetProjectQuery(id));
    }
}