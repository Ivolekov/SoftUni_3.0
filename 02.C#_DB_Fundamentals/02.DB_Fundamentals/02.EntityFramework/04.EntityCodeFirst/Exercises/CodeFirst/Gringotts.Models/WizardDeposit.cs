using System;
using System.ComponentModel.DataAnnotations;

namespace Gringotts.Models
{
    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(60)]
        public string Lastname { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(100)]
        public string MagicWandCreator { get; set; }

        public int MagicWandSize { get; set; }

        [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal DepositInterest { get; set; }

        public double DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
