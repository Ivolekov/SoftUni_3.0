namespace BookShopSystem.Data
{
    using Migrations;
    using Models;
    using System.Data.Entity;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.
                SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, 
                Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(b =>
                {
                    b.MapLeftKey("BookId");
                    b.MapRightKey("RelatedId");
                    b.ToTable("RelatedBooks");
                });
            base.OnModelCreating(modelBuilder);
        }
        public virtual IDbSet<Author> Author { get; set; }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}