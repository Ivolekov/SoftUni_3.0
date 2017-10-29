using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.MotorVihicles
{
    public class Plane : MotorVihicle
    {
        public string AirlineOwner { get; set; }

        public string Color { get; set; }

        public int PasingersCapacity { get; set; }
    }
}
