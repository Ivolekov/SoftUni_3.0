namespace StudentSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemContext")
        {
            this.Database.Initialize(true);
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homework { get; set; }

        public IDbSet<Resource> Resurses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<License> Licenses { get; set; }
    }
}