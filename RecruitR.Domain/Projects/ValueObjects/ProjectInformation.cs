using System.Collections.Generic;
using RecruitR.Domain.Projects.Enums;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Projects.ValueObjects
{
    public class ProjectInformation : ValueObject
    {
        public ProjectInformation(Type type, Category category)
        {
            Type = type;
            Category = category;
        }

        public Enums.Type Type { get; private set; }
        public Enums.Category Category { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Category;
        }
    }
}