using PizzaMore.Data;
using PIzzaMore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin
{
    public class Signin
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header header = new Header();
        public static void Main()
        {
            if (WebUtil.IsPost())
            {
                TryLogInUser();
            }
            ShowPage();
        }

        private static void ShowPage()
        {
            header.Print();
            WebUtil.PrintFileContent(Constants.Signin);
        }

        private static void TryLogInUser()
        {
            RequestParameters = WebUtil.RetrivePostParameters();
            string email = RequestParameters["email"];
            string password = PasswordHasher.Hash(RequestParameters["password"]);

            using (var context = new PizzaMoreContext())
            {
                User desitreUser = context.Users.SingleOrDefault(u => u.Email == email);
                if (desitreUser.Password == password)
                {
                    Session session = new Session();
                    session.User = desitreUser;
                    if (desitreUser != null)
                    {
                        header.AddCookie(new Cookie("sid", session.Id.ToString()));
                    }
                    context.Sessions.Add(session);
                    context.SaveChanges();
                }
            }
        }
    }
}
