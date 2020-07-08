using Microsoft.AspNetCore.Http;
using RecruitR.Infrastructure.Exceptions;

namespace RecruitR.Infrastructure.ProblemDetails
{
    public class EntityNotFoundDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public string EntityName { get; }
        public EntityNotFoundDetails(EntityNotFoundException exception)
        {
            Type = exception.Type;
            Status = StatusCodes.Status404NotFound;
            Title = nameof(EntityNotFoundException);
            Detail = exception.Message;
            EntityName = exception.EntityName;
        }
    }
}