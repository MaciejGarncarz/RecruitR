using System;
using RecruitR.Infrastructure;
using RecruitR.Projects.Dtos;

namespace RecruitR.Projects.Queries.GetProject
{
    public class GetProjectQuery : IQuery<ProjectDto>
    {
        public Guid Id { get; }

        public GetProjectQuery(Guid id)
        {
            Id = id;
        }
    }
}