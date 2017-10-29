namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SimpleMVC.App.Models;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }
        public DbSet<Knive> Knives { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
}