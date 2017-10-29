namespace PizzaForumApp.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaForumContext : DbContext
    {
        public PizzaForumContext()
            : base("PizzaForumContext")
        {

        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Login> Logins { get; set; }
        public IDbSet<Reply> Replies { get; set; }
        public IDbSet<Topic> Topics { get; set; }
    }
}