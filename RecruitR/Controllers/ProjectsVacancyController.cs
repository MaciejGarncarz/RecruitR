using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Projects.Commands.Vacancy.AddVacancy;
using RecruitR.Projects.Commands.Vacancy.DeleteVacancy;
using RecruitR.Projects.Commands.Vacancy.UpdateVacancy;
using RecruitR.Projects.Dtos;
using RecruitR.Projects.Queries.Vacancies.GetVacancies;

namespace RecruitR.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsVacancyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsVacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{projectId}/vacancies")]
        public async Task AddVacancy([FromRoute] Guid projectId, [FromBody] AddVacancyRequest request)
            => await _mediator.Send(
                new AddVacancyCommand(
                    request.Id, 
                    projectId, 
                    request.Name, 
                    request.Description, 
                    request.Status,
                    request.ExpirationDate
                    )
                );

        [HttpDelete("{projectId}/vacancies/{id}")]
        public async Task DeleteVacancy([FromRoute] Guid projectId, [FromRoute] Guid id)
            => await _mediator.Send(new DeleteVacancyCommand(id, projectId));

        [HttpPut("{projectId}/vacancies/{id}")]
        public async Task UpdateVacancy([FromRoute] Guid projectId, [FromRoute] Guid id,
            [FromBody] UpdateVacancyRequest request)
            => await _mediator.Send(
                new UpdateVacancyCommand(
                    id,
                    projectId,
                    request.Name,
                    request.Description,
                    request.Status,
                    request.ExpirationDate)
            );

        [HttpGet("{projectId}/vacancies")]
        public async Task<IEnumerable<VacancyDto>> GetVacancies(Guid projectId)
            => await _mediator.Send(new GetVacanciesQuery(projectId));
    }
}