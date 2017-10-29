namespace IssueTrackerApp.Utilities
{
    using System.Linq;

    public class AuthenticatedManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Data.Context.Logins.Any(l=>l.SessionId == sessionId && l.IsActive);
        }
    }
}
