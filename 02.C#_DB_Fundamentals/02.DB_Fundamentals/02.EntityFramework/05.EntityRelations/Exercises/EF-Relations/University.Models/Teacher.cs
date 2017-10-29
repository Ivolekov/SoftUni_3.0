using System.Collections.Generic;

namespace University.Models
{
    public class Teacher : Person
    {
        public string Email { get; set; }

        public decimal SalaryPerHour { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
