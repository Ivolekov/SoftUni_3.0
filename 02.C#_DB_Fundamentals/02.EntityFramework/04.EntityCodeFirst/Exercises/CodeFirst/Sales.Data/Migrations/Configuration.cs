namespace Sales.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sales.Data.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SalesContext";
        }

        protected override void Seed(SalesContext context)
        {
            context.Products.AddOrUpdate(
                p => p.Name,
                new Product { Name = "CocaCola", Quantity = 100, Price = 1.78m, },
                new Product { Name = "Fant", Quantity = 50, Price = 1.79m, },
                new Product { Name = "Victory", Quantity = 67, Price = 2.8m, },
                new Product { Name = "Milka", Quantity = 10, Price = 0.8m, });
            context.SaveChanges();

            context.Customers.AddOrUpdate(
                c => c.CreditCardNumber,
                new Customer { Name = "Ivan", Email = "iavn@abv.bg", CreditCardNumber = "456789098" },
                new Customer { Name = "Maira", Email = "maoira@abv.bg", CreditCardNumber = "123434676" },
                new Customer { Name = "Pesho", Email = "pesho@abv.bg", CreditCardNumber = "455468678" },
                new Customer { Name = "Sasho", Email = "sassho98@abv.bg", CreditCardNumber = "84322145" });
            context.SaveChanges();

            context.StoresLocation.AddOrUpdate(
                s => s.LocationName,
                new StoreLocation { LocationName = "Sofia" },
                new StoreLocation { LocationName = "Plovdiv" },
                new StoreLocation { LocationName = "Varna" },
                new StoreLocation { LocationName = "Burgas" });
            context.SaveChanges();

            if (!context.Sales.Any())
            {
                context.Sales.AddOrUpdate(
              s => s.Id,
              new Sale { ProductId = 1, CustomerId = 1, StoreLocationId = 2, Date = new DateTime(2016, 01, 01) },
              new Sale { ProductId = 2, CustomerId = 4, StoreLocationId = 1, Date = new DateTime(2016, 05, 11) },
              new Sale { ProductId = 3, CustomerId = 3, StoreLocationId = 3, Date = new DateTime(2016, 11, 06) },
              new Sale { ProductId = 4, CustomerId = 2, StoreLocationId = 4, Date = new DateTime(2016, 02, 09) });
                context.SaveChanges();
            }
          
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
