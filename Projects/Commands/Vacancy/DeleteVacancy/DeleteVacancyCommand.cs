using System;
using RecruitR.Infrastructure;

namespace RecruitR.Projects.Commands.Vacancy.DeleteVacancy
{
    public class DeleteVacancyCommand : ICommand
    {
        public Guid Id { get; }
        public Guid ProjectId { get; }

        public DeleteVacancyCommand(Guid id, Guid projectId)
        {
            Id = id;
            ProjectId = projectId;
        }
    }
}