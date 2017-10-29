using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.MotorVihicles;

namespace Vehicles.Models.Non_MotorVohocles
{
    public abstract class Carige
    {
        public int PassengerSeatCapacity { get; set; }

        public virtual Train Train { get; set; }
    }
}
