using System;
using RecruitR.Domain.Projects.Enums;
using Type = RecruitR.Domain.Projects.Enums.Type;

namespace RecruitR.Projects.Commands.CreateProject
{
    public class CreateProjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool RecruitingStatus { get; set; }
        public Type Type { get; set; }
        public Category Category { get; set; }
    }
}