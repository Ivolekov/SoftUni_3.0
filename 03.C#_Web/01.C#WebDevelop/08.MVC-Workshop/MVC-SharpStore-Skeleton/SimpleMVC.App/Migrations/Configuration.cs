namespace SimpleMVC.App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SimpleMVC.App.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMVC.App.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleMVC.App.Data.SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(k => k.Name, new Knive()
            {
                Name = "Sharp 3000",
                Price = 140,
                ImageUrl = "https://www.procouteaux.com/media/wysiwyg/santoku-knife.jpg"
            },
            new Knive()
            {
                Name = "Sharp 4",
                Price = 100,
                ImageUrl = "https://www.procouteaux.com/media/wysiwyg/t_579.jpg"
            },
            new Knive()
            {
                Name = "Sharp Ultimate",
                Price = 450,
                ImageUrl = "https://www.procouteaux.com/media/wysiwyg/couteau_japonais_1.jpg"
            }
            );
        }
    }
}
