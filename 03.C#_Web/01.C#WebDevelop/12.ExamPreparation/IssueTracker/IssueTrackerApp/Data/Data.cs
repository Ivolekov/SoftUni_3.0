namespace IssueTrackerApp.Data
{
    public class Data
    {
        private static IssueTrackerContext context;

        public static IssueTrackerContext Context => context ?? (context = new IssueTrackerContext());
    }
}
