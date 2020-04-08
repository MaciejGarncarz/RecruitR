using System;

namespace RecruitR.Infrastructure.Domain
{
    public class DomainException : Exception
    {
        public int Code { get; }

        public DomainException()
        {
        }

        public DomainException(int code)
        {
            Code = code;
        }

        public DomainException(string message, params object[] args)
            : this(500, message, args)
        {
        }

        public DomainException(int code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public DomainException(Exception innerException, string message, params object[] args)
            : this(innerException, 500, message, args)
        {
        }

        public DomainException(Exception innerException, int code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}