namespace SoftUniGameScore.Data
{
    using Models;
    using System.Data.Entity;

    public class SoftUniGameScoreContext : DbContext
    {

        public SoftUniGameScoreContext()
            : base("SoftUniGameScoreContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Game>(g => g.Games)
                .WithMany(u => u.Users)
                .Map(gu =>
                {
                    gu.MapLeftKey("UserId");
                    gu.MapRightKey("GameId");
                    gu.ToTable("UserGame");
                });
        }

    }
}