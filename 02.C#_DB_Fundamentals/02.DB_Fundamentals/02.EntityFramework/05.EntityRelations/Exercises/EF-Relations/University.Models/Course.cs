namespace University.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Enddate { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
