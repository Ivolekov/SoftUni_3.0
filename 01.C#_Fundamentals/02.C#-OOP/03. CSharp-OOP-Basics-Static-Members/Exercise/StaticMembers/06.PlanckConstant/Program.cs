using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PlanckConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation.Method();
        }
    }

    public class Calculation
    {
        public const double PlankConst = 6.62606896e-34;
        public const double Pi = 3.14159;

        public static void Method()
        {
            Console.WriteLine(PlankConst / (2 * Pi));
        }
    }
}
