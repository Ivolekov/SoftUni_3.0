using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Models;
using IssueTrackerApp.ViewModels;

namespace IssueTrackerApp.Services
{
    public class HomeService : Service
    {
        public LoginViewModel CheckedForLoginUser(HttpSession session)
        {
            var login = this.Context.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive);
            if (login != null)
            {
                LoginViewModel livm = new LoginViewModel()
                {
                    Username = login.User.Username
                };
                return livm;
            }
            else
            {
                return new LoginViewModel();
            }
        }
    }
}
