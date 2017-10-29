namespace Gringotts.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WizartContext : DbContext
    {
        public WizartContext()
            : base("name=WizartContext")
        {
        }
        public IDbSet<WizardDeposit> WizartDeposits { get; set; }
    }
}