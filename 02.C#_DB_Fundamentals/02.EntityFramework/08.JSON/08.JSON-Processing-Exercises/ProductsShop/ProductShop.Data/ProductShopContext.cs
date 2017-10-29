namespace ProductShop.Data
{
    using ProductsShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("ProductShopContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(u =>
                {
                    u.MapLeftKey("UserId");
                    u.MapRightKey("FriendId");
                    u.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}