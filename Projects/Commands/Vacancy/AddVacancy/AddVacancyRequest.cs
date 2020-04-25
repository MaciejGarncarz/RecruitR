using System;
using RecruitR.Domain.Projects.Enums;

namespace RecruitR.Projects.Commands.Vacancy.AddVacancy
{
    public class AddVacancyRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public VacancyStatus Status { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}