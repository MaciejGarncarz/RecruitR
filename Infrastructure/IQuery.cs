using MediatR;

namespace RecruitR.Infrastructure
{
    public interface IQuery<T> : IRequest<T>
    {
        
    }
}