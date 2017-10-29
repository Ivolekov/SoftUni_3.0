namespace LearningSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningSystem.Data.LearningSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LearningSystem.Data.LearningSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("student");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("trainer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "blogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("blogAuthor");
                manager.Create(role);
            }

            context.Courses.AddOrUpdate(c => c.Name, new Course[]
                {
                    new Course()
                    {
                        Name = "Programing Basics - March 2016",
                        Description = "Programing basics- е предназначен за начинаещи",
                        StartDate = new DateTime(2016, 03, 23),
                        EndDate = new DateTime(2016, 04, 25),
                    },
                    new Course()
                    {
                        Name = "Programing Fundamentals - April 2016",
                        Description = "Programing fundamentals- е предназначен за премиинали Progaramin Basics успешно",
                        StartDate = new DateTime(2016, 04, 28),
                        EndDate = new DateTime(2016, 05, 25),
                    },
                    new Course()
                    {
                        Name = "OOP - April 2016",
                        Description = "OOP е ще навлезете в детаилите на програмния език C#",
                        StartDate = new DateTime(2016, 04, 23),
                        EndDate = new DateTime(2016, 05, 25),
                    },
                    new Course()
                    {
                        Name = "OOD - May 2016",
                        Description = "OOD - как да пишем качествен програмен код",
                        StartDate = new DateTime(2016, 05, 03),
                        EndDate = new DateTime(2016, 06, 25),
                    },
                    new Course()
                    {
                        Name = "Asp.Net MVC 5 - May 2016",
                        Description = "Aps.Net- Как да се се направи Web application (Right Way)",
                        StartDate = new DateTime(2016, 05, 13),
                        EndDate = new DateTime(2016, 07, 25),
                    },
                    new Course()
                    {
                        Name = "Java Basics - March 2016",
                        Description = "Java basics- е предназначен за начинаещи",
                        StartDate = new DateTime(2016, 03, 23),
                        EndDate = new DateTime(2016, 04, 25),
                    },new Course()
                    {
                        Name = "JavaScript Basics - March 2016",
                        Description = "JavaScript basics- е предназначен за начинаещи",
                        StartDate = new DateTime(2016, 03, 23),
                        EndDate = new DateTime(2016, 04, 25),
                    },new Course()
                    {
                        Name = "PHP Basics - March 2016",
                        Description = "JavaScript basics- е предназначен за начинаещи",
                        StartDate = new DateTime(2017, 05, 23),
                        EndDate = new DateTime(2017, 06, 25),
                    }
                });
        }
    }
}
