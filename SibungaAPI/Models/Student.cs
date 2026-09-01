using System;

namespace SibungaAPI.Models
{
    public class Student
    {
        public string FullName { get; set; } = string.Empty;
        public string IdNo { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public bool FullTime { get; set; }

        public int? Age
        {
            get
            {
                if (!BirthDate.HasValue) return null;
                var today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
                var age = today.Year - BirthDate.Value.Year;
                if (today < BirthDate.Value.AddYears(age)) age--;
                return age;
            }
        }
    }
}
