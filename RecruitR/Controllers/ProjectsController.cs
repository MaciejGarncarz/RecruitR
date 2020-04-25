using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Projects.Commands.CreateProject;
using RecruitR.Projects.Commands.DeleteProject;
using RecruitR.Projects.Commands.UpdateProject;
using RecruitR.Projects.Dtos;
using RecruitR.Projects.Queries.GetProject;
using RecruitR.Projects.Queries.GetProjects;

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
        public async Task CreateProject([FromBody] CreateProjectRequest request)
            => await _mediator.Send(
                new CreateProjectCommand(
                    request.Id, 
                    request.Name, 
                    request.Description, 
                    request.RecruitingStatus, 
                    request.Type, 
                    request.Category
                    )
                );

        [HttpDelete("{id}")]
        public async Task DeleteProject([FromRoute] Guid id)
            => await _mediator.Send(new DeleteProjectCommand(id));

        [HttpPut("{id}")]
        public async Task UpdateProject([FromRoute] Guid id, [FromBody] UpdateProjectRequest request)
            => await _mediator.Send(new UpdateProjectCommand(
                id, 
                request.Name, 
                request.Description, 
                request.RecruitingStatus, 
                request.Type, 
                request.Category
                )
            );

        [HttpGet("{id}")]
        public async Task<ProjectDto> GetProject([FromRoute] Guid id)
            => await _mediator.Send(new GetProjectQuery(id));

        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> GetProjects()
            => await _mediator.Send(new GetProjectsQuery());
    }
}