using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Software : Component
    {
        private int capacityConsumption;
        private int memoryConsumption;
        private string hardwareComponentName;

        public Software(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption)
            : base(name)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
            this.hardwareComponentName = hardwareComponentName;

        }

        public virtual int CapacityConsumption
        {
            get { return this.capacityConsumption; }
            set { this.capacityConsumption = value; }
        }

        public virtual int MemoryConsumption { get; set; }

        public override string Type
        {
            get { return base.Type; }
            set { base.Type = GetType().Name; }
        }
    }
}