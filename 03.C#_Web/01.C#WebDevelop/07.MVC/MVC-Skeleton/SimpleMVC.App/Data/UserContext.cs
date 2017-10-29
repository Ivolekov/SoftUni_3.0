namespace SimpleMVC.App.Data
{
    using Models;
    using MVC.Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserContext : DbContext, IDbIdentityContext
    {
        public UserContext()
            : base("name=UserContext.cs")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}