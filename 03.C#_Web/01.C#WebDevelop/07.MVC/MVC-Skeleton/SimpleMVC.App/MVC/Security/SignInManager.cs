using SimpleHttpServer.Models;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.MVC.Security
{
    public class SignInManager
    {
        private IDbIdentityContext dbContext;
        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            Login login = dbContext.Logins.FirstOrDefault(x => x.SessionId == session.Id);
            if (login == null)
            {
                return false;
            }
            if (login.IsActive)
            {
                return true;
            }
            return false;
        }
    }
}
