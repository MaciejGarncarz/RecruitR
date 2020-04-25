using System;
using RecruitR.Infrastructure;

namespace RecruitR.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : ICommand
    {
        public Guid Id { get; }

        public DeleteProjectCommand(Guid id)
        {
            Id = id;
        }
    }
}