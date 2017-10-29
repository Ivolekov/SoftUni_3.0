using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class Single : HouseHold
    {
        public Single(decimal income, int numberOfRooms, decimal roomElectricity) 
            : base(income, numberOfRooms, roomElectricity)
        {
        }
    }
}