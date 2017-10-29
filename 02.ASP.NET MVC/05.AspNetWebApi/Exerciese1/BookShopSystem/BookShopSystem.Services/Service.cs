namespace BookShopSystem.Services
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class Service
    {
        protected Service()
        {
            this.Context = new BookShopContext();
        }

        protected BookShopContext Context { get; }
    }
}
