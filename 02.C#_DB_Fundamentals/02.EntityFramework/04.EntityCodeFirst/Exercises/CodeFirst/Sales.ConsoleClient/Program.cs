using Sales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();

            context.Customers.Count();
        }
    }
}