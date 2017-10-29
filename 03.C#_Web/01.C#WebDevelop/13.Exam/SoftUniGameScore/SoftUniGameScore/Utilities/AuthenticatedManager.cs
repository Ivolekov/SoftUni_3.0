namespace SoftUniGameScore.Utilities
{
    using Models;
    using System.Linq;

    public class AuthenticatedManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Data.Context.Logins.Any(l => l.SessionId == sessionId && l.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Data.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId && l.IsActive)?.User;
            return user;
        }

        public static bool IsAdmin(string sessionId)
        {
            User user = Data.Data.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId && l.IsActive)?.User;
            if (user.IsAdmin)
            {
                return true;
            }
            return false;
        }
    }
}
