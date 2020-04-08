
using System;

namespace RecruitR.Projects.Dtos
{
    // Add other proprties later
    public class ProjectDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsRecruiting { get; private set; }
        public string Category { get; private set; }
        public string Type { get; private set; }

        public ProjectDto(string name)
        {
            Name = name;
        }
    }
}