using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kermen
{
    public class Child
    {
        private decimal[] consumation;

        public Child(decimal[] consumation)
        {
            this.consumation = consumation;
        }

        public decimal TotalConsumation()
        {
            return this.consumation.Sum();
        }
    }
}