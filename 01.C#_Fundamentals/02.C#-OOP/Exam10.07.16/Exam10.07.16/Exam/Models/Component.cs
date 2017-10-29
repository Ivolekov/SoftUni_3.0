using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public abstract class Component
    {
        private string name;
        private string type;

        private int maximumCapacity;
        private int maximumMemory;

        private int memoryConsumation;
        private int capacityConsumation;

        protected Component(string name)
        {
            this.Name = name;
            this.Type = type;
            this.MemoryConsumation = memoryConsumation;
            this.MaximumMemory = maximumMemory;
            this.CapacityConsumation = capacityConsumation;
            this.MaximumCapacity = maximumCapacity;
        }

        public string Name { get; set; }

        public virtual int CapacityConsumation { get; set; }

        public virtual int MaximumCapacity { get; set; }

        public virtual int MaximumMemory { get; set; }

        public virtual int MemoryConsumation { get; set; }

        public virtual string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        
    }
}