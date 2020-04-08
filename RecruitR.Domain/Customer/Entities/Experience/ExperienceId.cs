using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Experience
{
    public class ExperienceId : IdentityBase
    {
        public ExperienceId(Guid value) : base(value)
        {
        }
    }
}