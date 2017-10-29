namespace CameraBazaar.Data.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CameraBazaar.Data.CameraBazaarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CameraBazaar.Data.CameraBazaarContext context)
        {
            //CameraBazaarContext contex = new CameraBazaarContext();
            //User user = new User()
            //{
            //    Email = "pesho@mail.com",
            //    Password = "123456",
            //    Phone = "+359",
            //    Username = "pesho"
            //};

            //contex.Users.Add(user);
            //contex.SaveChanges();
        }
    }
}
