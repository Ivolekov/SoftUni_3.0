namespace Unversity.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using University.Models;

    public class TPCUniversityContext : DbContext
    {
        public TPCUniversityContext()
            : base("name=TPCUniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teachers");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
