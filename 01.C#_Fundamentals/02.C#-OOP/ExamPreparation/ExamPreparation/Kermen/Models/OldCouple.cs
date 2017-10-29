using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class OldCouple : Couple
    {
        private const int NumberOfRooms = 3;
        private const decimal RoomElectricity = 15;

        private decimal stoveCost;

        public OldCouple(decimal pansionOne, decimal pansionTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost)
            : base(pansionOne, pansionTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Cunsumation
        {
            get { return base.Cunsumation + stoveCost; }
        }
    }
}