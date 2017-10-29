using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public abstract class Hardware : Component
    {
        private int maximumCapacity;
        private int maximumMemory;

        public Hardware(string name, int maximumCapacity, int maximumMemory)
            : base(name)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
        }

        public virtual int MaximumCapacity { get; set; }

        public virtual int MaximumMemory { get; set; }

        public override string Type
        {
            get { return base.Type; }
            set { base.Type = GetType().Name; }
        }
    }
}