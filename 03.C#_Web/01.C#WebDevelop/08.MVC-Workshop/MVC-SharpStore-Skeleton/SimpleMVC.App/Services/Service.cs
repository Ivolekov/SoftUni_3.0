using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Services
{
    using SimpleMVC.App.Data;

    public abstract class Service
    {
        protected SharpStoreContext context;
        public Service(SharpStoreContext context)
        {
            this.context = context;
        }
    }
}
