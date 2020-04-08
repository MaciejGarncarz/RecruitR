using System;
using Microsoft.AspNetCore.Http;

namespace RecruitR.Infrastructure.Domain
{
    public static class Guard
    {
        public static void AgainstNull(object value, string argument)
        {
            if (value == null)
                throw new DomainException(StatusCodes.Status400BadRequest, $"{argument} cannot be null");
        }

        public static void AgainstEmptyIdentity(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new DomainException(StatusCodes.Status400BadRequest, $"Identity cannot be empty");
        }

        public static void AgainstEmptyString(string value, string argument)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(StatusCodes.Status400BadRequest, $"{argument} cannot be empty");
        }
    }
}