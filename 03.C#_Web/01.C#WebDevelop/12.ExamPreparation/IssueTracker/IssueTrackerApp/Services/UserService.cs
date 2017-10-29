namespace IssueTrackerApp.Services
{
    using System;
    using IssueTrackerApp.BindingModels;
    using System.Text.RegularExpressions;
    using System.Linq;
    using IssueTrackerApp.Models;
    using IssueTrackerApp.Models.Enums;
    using System.Collections.Generic;
    using ViewModels;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class UserService : Service
    {

        public HashSet<RegistrationVerificationErrorViewModel> IsValidRegistretion(RegisterBindingModel model)
        {
            HashSet<RegistrationVerificationErrorViewModel> revm = new HashSet<RegistrationVerificationErrorViewModel>();

            if (model.Username.Length < 5 || model.Username.Length > 30)
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.UserNameLengthErrorMessage));
            }
            if (model.FullName.Length < 5)
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.FullNameTooShortMessage));
            }
            Regex regex = new Regex(@"[!@#$%^&*,.]");
            if (model.Password.Length < 8 || !regex.IsMatch(model.Password)
                || !model.Password.Any(char.IsDigit) || !model.Password.Any(char.IsUpper))
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.PasswordIncorrectFormatMessage));
            }
            if (model.Password != model.RepeatPassword)
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.PasswordsDoNotMatchMessage));
            }

            return revm;
        }

        public HashSet<RegistrationVerificationErrorViewModel> IsLoginModelValid(LoginBindingModel model)
        {
            HashSet<RegistrationVerificationErrorViewModel> revm = new HashSet<RegistrationVerificationErrorViewModel>();

            if (!this.Context.Users.Any(u => u.Username == model.Username))
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.UsernameError));
            }
            if (!this.Context.Users.Any(u => u.Password == model.Password))
            {
                revm.Add(new RegistrationVerificationErrorViewModel(Constants.WrongPassword));
            }
            return revm;
        }

        public bool LoginUser(User user, string sessionId)
        {
            Login login = new Login()
            {
                SessionId = sessionId,
                IsActive = true,
                User = user
            };
            this.Context.Logins.Add(login);
            this.Context.SaveChanges();
            return true;
        }

        public User GetUserFromLoginBind(LoginBindingModel model)
        {
            return this.Context.Users.FirstOrDefault(u => u.Username == model.Username
            && u.Password == model.Password);
        }

        public User GetUserFromRegisterBind(RegisterBindingModel model)
        {
            return new User()
            {
                FullName = model.FullName,
                Username = model.Username,
                Password = model.Password
            };
        }

        public bool RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.Role = Role.Administrator;
            }
            else
            {
                user.Role = Role.ReqularUser;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
            return true;
        }

        public void LogoutUser(string sessionId, HttpResponse response)
        {
            var login = this.Context.Logins.FirstOrDefault(l=>l.SessionId==sessionId);
            login.IsActive = false;
            this.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
