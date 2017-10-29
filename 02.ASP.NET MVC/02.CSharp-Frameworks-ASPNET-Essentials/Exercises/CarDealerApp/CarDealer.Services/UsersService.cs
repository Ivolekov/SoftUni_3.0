namespace CarDealer.Services
{
    using System;
    using CarDealer.Data;
    using Models.BindingModels;
    using Models;
    using System.Linq;
    using AutoMapper;

    public class UsersService : Service
    {
        public UsersService(CarDealerContext context) : base(context)
        {
        }

        public void RegisterUser(RegisterUserBindingModel bind)
        {
            User model = Mapper.Map<RegisterUserBindingModel, User>(bind);
            this.Context.Users.Add(model);
            this.Context.SaveChanges();
        }

        public bool IsUserExists(LoginBindingModel bind)
        {
            if (this.Context.Users.Any(user => user.Username == bind.Username && user.Password == bind.Password))
            {
                return true;
            }

            return false;
        }

        public void LoginUser(LoginBindingModel bind, string sessionSessionId)
        {
            if (!this.Context.Logins.Any(l=>l.SessionId == sessionSessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionSessionId });
                this.Context.SaveChanges();
            }

            Login myLogin = this.Context.Logins.FirstOrDefault(l => l.SessionId == sessionSessionId);
            myLogin.IsActive = true;
            User model =
                this.Context.Users.FirstOrDefault(u => u.Username == bind.Username && u.Password == bind.Password);
            myLogin.User = model;
            this.Context.SaveChanges();
        }
    }
}
