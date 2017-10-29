namespace IssueTrackerApp.Data
{
    using Models;
    using System.Data.Entity;

    public class IssueTrackerContext : DbContext
    {
        
        public IssueTrackerContext()
            : base("IssueTrackerContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<Login> Logins { get; set; }
    }
}