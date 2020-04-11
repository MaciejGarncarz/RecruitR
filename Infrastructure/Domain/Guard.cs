using System;
using Microsoft.AspNetCore.Http;
using RecruitR.Infrastructure.Helpers;

namespace RecruitR.Infrastructure.Domain
{
    public static class Guard
    {
        public static void AgainstNull(object value, string argument)
        {
            if (value == null)
                throw new LogicException(StatusCodes.Status400BadRequest, $"{argument} cannot be null");
        }

        public static void AgainstEmptyIdentity(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new LogicException(StatusCodes.Status400BadRequest, $"Identity cannot be empty");
        }

        public static void AgainstEmptyString(string value, string argument)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new LogicException(StatusCodes.Status400BadRequest, $"{argument} cannot be empty");
        }

        public static void AgainstInvalidDateRange(DateTime start, DateTime end, DateTime dateToCheck)
        {
            var dateRangeChecker = new DateTimeRangeChecker(start, end);

            if (!dateRangeChecker.Includes(dateToCheck))
                throw new LogicException("Date out of range");
        }

    }
}