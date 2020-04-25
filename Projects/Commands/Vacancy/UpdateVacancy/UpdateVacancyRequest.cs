using System;
using RecruitR.Domain.Projects.Enums;

namespace RecruitR.Projects.Commands.Vacancy.UpdateVacancy
{
    public class UpdateVacancyRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VacancyStatus Status { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}