namespace Sales.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
        }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<StoreLocation> StoresLocation { get; set; }
    }
}