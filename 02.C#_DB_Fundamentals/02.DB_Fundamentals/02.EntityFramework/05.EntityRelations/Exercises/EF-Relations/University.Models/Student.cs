using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Student : Person
    {
        public int AvgGrade { get; set; }

        public string Attendance { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
