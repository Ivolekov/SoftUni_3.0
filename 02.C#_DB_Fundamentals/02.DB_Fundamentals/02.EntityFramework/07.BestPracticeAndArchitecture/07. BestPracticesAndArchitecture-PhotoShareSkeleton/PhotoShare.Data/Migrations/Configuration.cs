namespace PhotoShare.Data.Migrations
{
    using Interfaces;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
            IUnitOfWork unit = new UnitOfWork();
            //TODO Seed some data in the database
            unit.Tags.Add(new Tag() { Name = "#summer" });
            unit.Tags.Add(new Tag() { Name = "#NYE2017" });
            unit.Tags.Add(new Tag() { Name = "#NoMakeUp#" });
            Town bs = new Town() { Name = "Burgas", Country = "Bulgaria" };
            Town vn = new Town() { Name = "Varna", Country = "Bulgaria" };
            Town tr = new Town() { Name = "Turin", Country = "Italy" };
            unit.Towns.Add(bs);
            unit.Towns.Add(vn);
            unit.Towns.Add(tr);
            unit.Users.Add(new User() { Username = "pesho", Password = "KKkk??pmer00", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            unit.Users.Add(new User() { Username = "gosho", Password = "KLoP0k?erl93", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            unit.Users.Add(new User() { Username = "minka", Password = "Lpkk!?asdrjj", Email = "pesho@peshov.bg", Age = 20,RegisteredOn = DateTime.Now,LastTimeLoggedIn = DateTime.Now , BornTown = bs,CurrentTown = vn,IsDeleted = false,});
            //TODO seed albums
            //TODO seed album roles
            //TODO seed pictures

            context.SaveChanges();
            //unit.Commit();
        }
    }
}
