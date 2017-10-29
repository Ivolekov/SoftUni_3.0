using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    class Ferrari:ICar
    {
        public const string model = "488-Spider";
        public string driverName;

        public Ferrari(string driverName)
        {
            this.Name = driverName;
        }

        public string Name { get; set; }

        public string Model
        {
            get { return model; }
        }

        public void Break()
        {
            Console.Write("Brakes!");
        }

        public void FullGas()
        {
            Console.Write("Zadu6avam sA!");
        }
    }
}
