using System;

namespace RecruitR.Infrastructure.Helpers
{
    public class DateTimeRangeChecker : IRangeChecker<DateTime>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateTimeRangeChecker(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool Includes(DateTime value)
        {
            // Should throw exception
            if (Start > End)
                return false;


            return Start <= value && value <= End;
        }
    }
}