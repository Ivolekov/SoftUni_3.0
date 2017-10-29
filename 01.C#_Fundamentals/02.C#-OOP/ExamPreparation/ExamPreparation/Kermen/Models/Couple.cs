using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class Couple : HouseHold
    {
        private decimal tvCost;
        private decimal fridgeCost;

        public Couple(decimal incomeOne, decimal incomeTwo, int numberOfRooms, decimal roomElectricity, decimal tvCost, decimal fridgeCost)
            : base(incomeOne + incomeTwo, numberOfRooms, roomElectricity)
        {
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override int Population
        {
            get { return base.Population + 1; }
        }

        public override decimal Cunsumation
        {
            get { return this.tvCost + this.fridgeCost + base.Cunsumation; }
        }


    }
}