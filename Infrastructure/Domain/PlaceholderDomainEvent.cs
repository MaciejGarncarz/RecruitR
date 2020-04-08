using System;

namespace RecruitR.Infrastructure.Domain
{
    public class PlaceholderDomainEvent : IDomainEvent
    {
        public Guid CorrelationId { get; }
        public DateTime OccuredOn { get; }

        public PlaceholderDomainEvent(Guid correlationId, DateTime occuredOn)
        {
            CorrelationId = correlationId;
            OccuredOn = occuredOn;
        }
    }
}