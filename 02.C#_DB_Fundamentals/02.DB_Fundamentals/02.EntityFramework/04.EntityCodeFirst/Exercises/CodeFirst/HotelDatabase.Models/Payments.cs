using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AccountNumber { get; set; }

        public DateTime FirstDateOccupied { get; set; }

        public DateTime LastDateOccupied { get; set; }

        public DateTime TotalDays { get; set; }

        public decimal AmountCharged { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal PaymentTotal { get; set; }

        public string Notes { get; set; }
    }
}
