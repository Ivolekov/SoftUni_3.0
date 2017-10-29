using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class MotorVihicle : Vihicle
    {
        public int NumberOfEngines { get; set; }

        public string EngineType { get; set; }

        public double TankCapacity { get; set; }
    }
}
