namespace CameraBazaar.App.Security
{
    using CameraBazaar.Data;
    using System.Linq;
    public static class SignInManager
    {
        private static CameraBazaarContext Context = new CameraBazaarContext();

        public static bool IsAuthenticated(string sessionId)
        {
            return Context.Logins.Any(s=>s.SessionId == sessionId && s.IsActive);
        }
    }
}