namespace Unversity.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using University.Models;

    public class TPHUniversityContext : DbContext
    {
        public TPHUniversityContext()
            : base("name=TPHUniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }
    }
}