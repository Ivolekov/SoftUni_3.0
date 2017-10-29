using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.MotorVihicles
{
    public class Car : MotorVihicle
    {
        public int NumberOfDoors { get; set; }

        public string InformationOfInsurance { get; set; }
    }
}
