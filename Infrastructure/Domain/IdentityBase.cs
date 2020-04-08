using System;

namespace RecruitR.Infrastructure.Domain
{
    public abstract class IdentityBase
    {
        public Guid Value { get; }

        protected IdentityBase(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IdentityBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(IdentityBase other)
        {
            return this.Value == other.Value;
        }

        public static bool operator ==(IdentityBase obj1, IdentityBase obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }
        public static bool operator !=(IdentityBase x, IdentityBase y)
        {
            return !(x == y);
        }
    }
}