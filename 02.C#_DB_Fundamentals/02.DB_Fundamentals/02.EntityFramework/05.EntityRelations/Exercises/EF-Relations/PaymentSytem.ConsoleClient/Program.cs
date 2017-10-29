using PaymetSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSytem.ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            TPCBillsPaymentContext context = new TPCBillsPaymentContext();
            context.Database.Initialize(true);
        }
    }
}
