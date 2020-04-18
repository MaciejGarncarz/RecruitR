using System;

namespace RecruitR.Infrastructure.Domain
{
    public class PlaceholderDomainEvent : IDomainEvent
    {
        public Guid CorrelationId { get; }
        public DateTime OccuredOn { get; }
        public string Message { get; set; }

        public PlaceholderDomainEvent(Guid correlationId, DateTime occuredOn, string message)
        {
            CorrelationId = correlationId;
            OccuredOn = occuredOn;
            Message = message;
        }
    }
}