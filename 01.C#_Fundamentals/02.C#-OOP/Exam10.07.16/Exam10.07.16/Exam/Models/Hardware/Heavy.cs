using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Heavy : Hardware
    {
        public Heavy(string name, int maximumCapacity, int maximumMemory)
            : base(name, maximumCapacity, maximumMemory)
        {
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity; }
            set
            {
                base.MaximumCapacity = value * 2;
            }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory; }
            set
            {
                int decreases = (int)(value * 0.25);
                base.MaximumMemory = value - decreases;
            }
        }
    }
}