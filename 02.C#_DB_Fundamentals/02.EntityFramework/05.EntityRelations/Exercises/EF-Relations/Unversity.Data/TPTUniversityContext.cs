namespace Unversity.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using University.Models;

    public class TPTUniversityContext : DbContext
    {
        public TPTUniversityContext()
            : base("name=TPTUniversityContext")
        {

        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            base.OnModelCreating(modelBuilder);
        }
    }
}
