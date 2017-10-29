namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PizzaMore.Models;

    public class PizzaMoreMVCContext : DbContext
    {
        public PizzaMoreMVCContext()
            : base("PizzaMoreMVCContext")
        {
        }

        public IDbSet<Pizza> Pizzas { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Session> Sessions { get; set; }
    }
}