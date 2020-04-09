using System;

namespace RecruitR.Infrastructure.Domain
{
    public class LogicException : Exception
    {
        public int Code { get; }

        public LogicException()
        {
        }

        public LogicException(int code)
        {
            Code = code;
        }

        public LogicException(string message, params object[] args)
            : this(500, message, args)
        {
        }

        public LogicException(int code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public LogicException(Exception innerException, string message, params object[] args)
            : this(innerException, 500, message, args)
        {
        }

        public LogicException(Exception innerException, int code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}