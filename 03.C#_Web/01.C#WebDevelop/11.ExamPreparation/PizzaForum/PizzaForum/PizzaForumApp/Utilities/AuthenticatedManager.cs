namespace PizzaForumApp.Utilities
{
    using Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AuthenticatedManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Data.Context.Logins.Any(l => l.SessionId == sessionId && l.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Data.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId && l.IsActive)?.User;
            if (user != null)
            {
                ViewBag.Bag["username"] = user.Username;
            }

            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            Login currentLogin = Data.Data.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId);
            currentLogin.IsActive = false;
            Data.Data.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
