using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.Entities.Skills
{
    public class SkillId : IdentityBase
    {
        public SkillId(Guid value) : base(value)
        {
        }
    }
}