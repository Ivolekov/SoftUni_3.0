namespace IssueTrackerApp.Models
{
    using Enums;
    using System;
    public class Issue
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public DateTime? CreatingDate { get; set; }

        public virtual User Author { get; set; }
    }
}
