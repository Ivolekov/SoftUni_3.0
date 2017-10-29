using PizzaMore.Data;
using PIzzaMore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signup
{
    public class Signup
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header header = new Header();

        public static void Main()
        {
            if (WebUtil.IsPost())
            {
                RegisterUser();
            }
            ShowPage();
        }

        private static void ShowPage()
        {
            header.Print();
            WebUtil.PrintFileContent(Constants.Signup);
        }

        private static void RegisterUser()
        {
            RequestParameters = WebUtil.RetrivePostParameters();
            string email = RequestParameters["email"];
            string password = RequestParameters["password"];
            var user = new User
            {
                Email = email,
                Password = PasswordHasher.Hash(password)
            };

            using (var context = new PizzaMoreContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
