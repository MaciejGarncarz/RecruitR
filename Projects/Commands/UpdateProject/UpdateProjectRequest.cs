using RecruitR.Domain.Projects.Enums;

namespace RecruitR.Projects.Commands.UpdateProject
{
    public class UpdateProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool RecruitingStatus { get; set; }
        public Type Type { get; set; }
        public Category Category { get; set; }
    }
}