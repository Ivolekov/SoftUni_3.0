using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Customer
    {
        private ICollection<Sale> salesForCustomers;

        public Customer()
        {
            this.salesForCustomers = new HashSet<Sale>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> SalesForCustomers
        {
            get { return this.salesForCustomers; }
            set { this.salesForCustomers = value; }
        }
    }
}
