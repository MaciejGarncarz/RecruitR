using System;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Projects.Entities
{
    public class VacancyId : IdentityBase
    {
        public VacancyId(Guid value) : base(value)
        {
        }
    }
}