using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.MotorVihicles
{
    public abstract class Ship : MotorVihicle
    {
        public string Nationality { get; set; }

        public string CaptanName { get; set; }

        public int SizeOfShipCrew { get; set; }
    }
}
