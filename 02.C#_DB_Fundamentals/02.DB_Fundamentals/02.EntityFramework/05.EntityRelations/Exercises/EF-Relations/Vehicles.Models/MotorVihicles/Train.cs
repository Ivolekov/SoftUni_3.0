using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Non_MotorVohocles;

namespace Vehicles.Models.MotorVihicles
{
    public class Train : MotorVihicle
    {

        public Train()
        {
            this.Cariges = new HashSet<Carige>();
        }
        public virtual Lokomotiv Lokomotiv { get; set; }

        public int NumberOfCariges { get; set; }

        public virtual ICollection<Carige> Cariges { get; set; }
    }
}
