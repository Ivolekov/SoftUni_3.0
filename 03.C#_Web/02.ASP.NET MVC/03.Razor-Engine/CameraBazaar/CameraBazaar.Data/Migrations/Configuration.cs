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
            context.Users.AddOrUpdate(
              u => u.Email,
              new User
              {
                  Username = "Andrew",
                  Email = "mail@mail.com",
                  Password = "123456",
                  Phone = "+359878765"
              });
        }
    }
}
