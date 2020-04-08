using System.Collections.Generic;
using RecruitR.Infrastructure.Domain;

namespace RecruitR.Domain.Customer.ValueObjects
{
    public class PersonalInfo : ValueObject
    {
        public string Description { get; }
        public string Nationality { get; }
        public Gender Gender { get; }

        public PersonalInfo(string description, string nationality, Gender gender)
        {
            Description = description;
            Nationality = nationality;
            Gender = gender;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Description;
            yield return Nationality;
            yield return Gender;
        }
    }
}