using System;

namespace RecruitR.Infrastructure.Exceptions
{
    public class EntityNotFound : Exception
    {
        public string EntityName { get; }
        public string Message { get; }

        public EntityNotFound(string entityName)
        {
            EntityName = entityName;
            Message = $"{entityName} not found";
        }
    }
}