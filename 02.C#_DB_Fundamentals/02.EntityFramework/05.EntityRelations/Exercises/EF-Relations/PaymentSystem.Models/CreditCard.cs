using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class CreditCard : BillingDetail
    {
        public string CardType { get; set; }

        public DateTime ExpirationMonth { get; set; }

        public DateTime ExpirationYear { get; set; }

    }
}
