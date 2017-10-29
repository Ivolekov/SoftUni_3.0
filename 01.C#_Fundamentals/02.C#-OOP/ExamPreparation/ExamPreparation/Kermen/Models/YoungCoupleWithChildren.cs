using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost,
            decimal fridgeCost, decimal laptopCost, Child[] children)
            : base(salaryOne, salaryTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Cunsumation
        {
            get { return base.Cunsumation + this.children.Sum(x => x.TotalConsumation()); }
        }

        public override int Population
        {
            get { return base.Population + children.Length; }
        }
    }
}