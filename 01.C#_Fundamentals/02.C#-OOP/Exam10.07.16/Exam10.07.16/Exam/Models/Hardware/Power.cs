using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Power : Hardware
    {
        public Power(string name, int maximumCapacity, int maximumMemory)
            : base(name, maximumCapacity, maximumMemory)
        {
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity; }
            set
            {
                int decreases = (int)(value * 0.75);

                base.MaximumCapacity = value - decreases;
            }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory; }
            set
            {
                int increases = (int)(value * 0.75);
                base.MaximumMemory = value + increases;
            }
        }
    }
}