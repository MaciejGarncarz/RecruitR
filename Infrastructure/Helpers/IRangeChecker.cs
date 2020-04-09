namespace RecruitR.Infrastructure.Helpers
{
    public interface IRangeChecker<T>
    {
        public T Start { get; }
        public T End { get; }
        bool Includes(T value);
    }
}