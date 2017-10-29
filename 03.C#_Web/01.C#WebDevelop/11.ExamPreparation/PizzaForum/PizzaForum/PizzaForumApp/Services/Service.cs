namespace PizzaForumApp.Services
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }
        protected PizzaForumContext Context { get; }
    }
}
