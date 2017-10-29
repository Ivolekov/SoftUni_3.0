namespace PaymetSystem.Data
{
    using PaymentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TPHBillsPaymentContext : DbContext
    {
        public TPHBillsPaymentContext()
            : base("TPHBillsPaymentContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<BillingDetail> BillingDetails { get; set; }
    }
}