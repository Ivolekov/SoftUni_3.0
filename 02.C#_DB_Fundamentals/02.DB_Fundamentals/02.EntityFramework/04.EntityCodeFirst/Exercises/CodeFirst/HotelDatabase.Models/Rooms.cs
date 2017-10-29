using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
    public class Rooms
    {
        [Key]
        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public string BedType { get; set; }

        public float Rate { get; set; }

        public string RoomStatus { get; set; }

        public string Notes { get; set; }

    }
}
