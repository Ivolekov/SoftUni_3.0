using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal money;

        protected HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.money = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public virtual int Population
        {
            get { return 1; }
        }

        public virtual decimal Cunsumation
        {
            get { return this.numberOfRooms * this.roomElectricity; }
        }

        public void GetIncome()
        {
            this.money += this.income;
        }

        public bool CanPayBills()
        {
            return this.money >= this.Cunsumation;
        }

        public void PayBills()
        {
            this.money -= this.Cunsumation;
        }
    }
}