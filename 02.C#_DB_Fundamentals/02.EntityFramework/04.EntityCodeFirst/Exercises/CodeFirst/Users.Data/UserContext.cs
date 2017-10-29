namespace Users.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapLeftKey("FriendId");
                    m.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
        public IDbSet<User> Users { get; set; }

        public IDbSet<Town> Towns { get; set; }
    }
}