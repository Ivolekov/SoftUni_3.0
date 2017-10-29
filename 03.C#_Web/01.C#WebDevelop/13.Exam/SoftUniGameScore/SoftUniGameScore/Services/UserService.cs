namespace SoftUniGameScore.Services
{
    using BindingModels;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;
    using SimpleHttpServer.Utilities;
    using SimpleHttpServer.Models;

    public class UserService : Service
    {
        public bool IsRegisterViewModelValid(RegisterUserBindingModel bind)
        {
            if (!bind.Email.Contains("@") || !bind.Email.Contains("."))
            {
                return false;
            }

            if (this.Context.Users.Any(u => u.Email == bind.Email))
            {
                return false;
            }

            Regex regexForPass = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}");
            if (bind.Password.Length < 6 || !regexForPass.IsMatch(bind.Password))
            {
                return false;
            }

            if (bind.Password != bind.ConfirmPassword)
            {
                return false;
            }

            if (string.IsNullOrEmpty(bind.FullName))
            {
                return false;
            }
            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel bind)
        {
            return new User()
            {
                Email = bind.Email,
                Password = bind.Password,
                Fullname = bind.FullName
            };
        }

        public void RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool IsLoginModelValid(LoginUserBindingModel bind)
        {
            if (!this.Context.Users.Any(u => (u.Email == bind.Email) && u.Password == bind.Password))
            {
                return false;
            }
            return true;
        }

        public void LoginUser(User user, string sessionId)
        {
            Login login = new Login()
            {
                SessionId = sessionId,
                IsActive = true,
                User = user
            };
            this.Context.Logins.Add(login);
            this.Context.SaveChanges();
        }

        public void LogoutUser(string sessionId, HttpResponse response)
        {
            var login = this.Context.Logins.FirstOrDefault(l => l.SessionId == sessionId);
            login.IsActive = false;
            this.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel bind)
        {
            return this.Context.Users.First(u => (u.Email == bind.Email)
            && u.Password == bind.Password);
        }
    }
}
