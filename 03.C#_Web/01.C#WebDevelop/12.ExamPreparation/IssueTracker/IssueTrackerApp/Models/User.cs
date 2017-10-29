namespace IssueTrackerApp.Models
{
    using Enums;
    using System.Collections.Generic;
    public class User
    {
        public User()
        {
            this.Issues = new HashSet<Issue>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public Role Role { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
