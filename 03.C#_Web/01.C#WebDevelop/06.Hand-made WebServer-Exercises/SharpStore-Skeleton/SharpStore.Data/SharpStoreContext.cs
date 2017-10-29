namespace SharpStore.Data
{
    using Models;
    using System;
    using System.Data.Entity;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public DbSet<Knife> Knives { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}