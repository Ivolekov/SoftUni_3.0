using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 20;

        private decimal laptopCost;

        public YoungCouple(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(salaryOne, salaryTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(decimal salaryOne, decimal salaryTwo, int numberOfRooms, decimal roomElectricity,
            decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(salaryOne, salaryTwo, NumberOfRooms, RoomElectricity, fridgeCost, tvCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Cunsumation
        {
            get { return base.Cunsumation + this.laptopCost * 2; }
        }


    }
}