using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Express : Software
    {
        public Express(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption)
            : base(hardwareComponentName,name, capacityConsumption, memoryConsumption)
        {
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption * 2; }
        }
    }
}