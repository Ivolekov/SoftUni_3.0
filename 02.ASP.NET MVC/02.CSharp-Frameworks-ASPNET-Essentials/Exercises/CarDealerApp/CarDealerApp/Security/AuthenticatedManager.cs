using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Security
{
    public class AuthenticatedManager
    {
        private static CarDealerContext context = new CarDealerContext();

        public static bool IsAuthenticated(string sessionId)
        {
            if (context.Logins.Any(l=>l.SessionId == sessionId && l.IsActive))
            {
                return true;
            }
            return false;
        }

        internal static void Logout(string sessionId)
        {
            Login login = context.Logins.FirstOrDefault(l => l.SessionId == sessionId);
            login.IsActive = false;
            context.SaveChanges();
        }

        internal static User GetAuthenticatedUsers(string sessionId)
        {
            var firstOrDefault = context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive);
            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.User;
                if (authenticatedUser != null)
                    return authenticatedUser;
            }

            return null;
        }
    }
}