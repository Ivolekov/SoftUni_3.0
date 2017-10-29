namespace CarDealer.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("CarDealerContext")
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supllier> Suplliers { get; set; }
    }
}