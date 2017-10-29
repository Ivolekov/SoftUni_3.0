using SimpleMVC.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IDbIdentityContext
    {
        DbSet<User> Users { get; }
        DbSet<Login> Logins { get; }

        void SaveChanges();
    }
}
