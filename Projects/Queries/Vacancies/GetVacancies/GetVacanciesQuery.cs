using System;
using System.Collections.Generic;
using RecruitR.Infrastructure;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.Vacancies.GetVacancies
{
    public class GetVacanciesQuery : IQuery<IEnumerable<VacancyDto>>
    {
        public Guid ProjectId { get; }

        public GetVacanciesQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}