namespace CameraBazaar.Service
{
    using CameraBazaar.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Service
    {
        private CameraBazaarContext context;

        protected Service()
        {
            this.context = new CameraBazaarContext();
        }

        protected CameraBazaarContext Context => this.context;
    }
}
