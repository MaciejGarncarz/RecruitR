using MediatR;

namespace Infrastructure
{
    public interface IQuery<T> : IRequest<T>
    {
        
    }
}