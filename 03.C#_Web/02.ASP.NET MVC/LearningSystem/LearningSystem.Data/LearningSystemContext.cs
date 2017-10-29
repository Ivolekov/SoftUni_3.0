namespace LearningSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LearningSystemContext : IdentityDbContext<ApplicationUser>
    {
        public LearningSystemContext()
              : base("name=LearningSystemContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Article> Articles { get; set; }
        public static LearningSystemContext Create()
        {
            return new LearningSystemContext();
        }
    }
}