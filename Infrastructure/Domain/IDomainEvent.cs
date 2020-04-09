using System;
using MediatR;

namespace RecruitR.Infrastructure.Domain
{
    public interface IDomainEvent : INotification
    {
        public Guid CorrelationId { get; }
        public DateTime OccuredOn { get; }
        public string Message { get; }
    }
}