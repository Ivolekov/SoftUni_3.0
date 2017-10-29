using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
    public class Occupancies
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOccupied { get; set; }

        public int AccountNumber { get; set; }

        public int RoomNumber { get; set; }

        public float RateApplied { get; set; }

        public decimal PhoneCharge { get; set; }

        public string Notes { get; set; }
    }
}
