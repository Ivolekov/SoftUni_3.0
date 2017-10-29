using PaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymetSystem.Data
{
    public class TPCBillsPaymentContext : DbContext
    {
        public TPCBillsPaymentContext()
            :base("TPCBillsPaymentContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BillingDetail>();

            modelBuilder.Entity<CreditCard>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CreditCards");
            });
            modelBuilder.Entity<BankAcount>().Map(m => 
            {
                m.MapInheritedProperties();
                m.ToTable("BankAcounts");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
