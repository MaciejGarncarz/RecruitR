using System;

namespace RecruitR.Infrastructure.Exceptions
{
    public class DomainRuleViolation : Exception
    {
        public DomainRuleViolation(string message) : base(message)
        {
            
        }
    }
}