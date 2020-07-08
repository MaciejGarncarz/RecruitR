using System;

namespace RecruitR.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string EntityName { get; }
        public string Message { get; }
        public string Type { get; }

        public EntityNotFoundException(string entityName)
        {
            EntityName = entityName;
            Message = $"{entityName} not found";
            Type = ExceptionType.Database;
        }
    }
}