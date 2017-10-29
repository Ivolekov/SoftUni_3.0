using PaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymetSystem.Data
{
    public class TPTBillsPaymentContext : DbContext
    {
        public TPTBillsPaymentContext()
            :base("TPTBillsPaymentContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
            modelBuilder.Entity<BankAcount>().ToTable("BankAcounts");
            base.OnModelCreating(modelBuilder);
        }
    }
}
