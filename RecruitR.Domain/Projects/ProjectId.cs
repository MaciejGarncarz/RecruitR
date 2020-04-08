using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Projects
{
    public class ProjectId : IdentityBase
    {
        public ProjectId(Guid value) : base(value)
        {
        }
    }
}