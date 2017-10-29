using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class BankAcount : BillingDetail
    {
        public string BankName { get; set; }

        public string SWIFTCode { get; set; }
    }
}
