using CameraBazaar.Data;

namespace CameraBazaar.Service
{
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
