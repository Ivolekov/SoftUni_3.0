using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Light : Software
    {
        public Light(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption)
            : base(hardwareComponentName, name, capacityConsumption, memoryConsumption)
        {
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption / 2; }
        }

        public override int CapacityConsumption
        {
            get { return (int)(base.CapacityConsumption * 0.5 + base.CapacityConsumption); }
        }
    }
}