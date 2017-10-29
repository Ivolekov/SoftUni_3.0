using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class Vihicle
    {
        public int Id { get; set; }

        public string Manifacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int MaxSpeed { get; set; }
    }
}
