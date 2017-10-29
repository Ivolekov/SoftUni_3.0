namespace IssueTrackerApp.Services
{
    using IssueTrackerApp.Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }
        protected IssueTrackerContext Context { get; }
    }
}
