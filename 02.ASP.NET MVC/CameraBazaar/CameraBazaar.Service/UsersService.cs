namespace CameraBazaar.Service
{
    using AutoMapper;
    using Models.BindingModels.Users;
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    public class UsersService : Service
    {
        public void RegisterUser(RegisterUserBindingModel bind)
        {
           // var user1 = this.Context.Users.Where(u=>u.Username == "pesho").Select(u=>u.Email);
            User user = Mapper.Map<RegisterUserBindingModel, User>(bind);
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }
    }
}
