using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Analyze
    {
        public List<Hardware> hardware;
        public List<Software> software;

        public Analyze()
        {
            this.hardware = new List<Hardware>();
            this.software = new List<Software>();
        }

        public int TotalConsumationCapacity
        {
             get { return this.software.Sum(x => x.CapacityConsumption);}
        }

        public int TotalCapacity
        {
            get { return this.hardware.Sum(x => x.MaximumCapacity); }
        }

        public List<Hardware> Hardware
        {
            get { return this.hardware; }
            set
            {
                this.hardware = value;
            }
        }

        public List<Software> Software
        {
            get { return this.software; }
            set
            {
                if (TotalConsumationCapacity <= TotalCapacity)
                {

                }
                this.software = value;
                

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("System Analysis")
                .AppendLine($"Hardware Components: {hardware.Count}")
                .AppendLine($"Software Components: {software.Count}")
                .AppendLine($"Total Operational Memory: {software.Sum(x => x.MemoryConsumption)} / {hardware.Sum(x => x.MaximumMemory)}")
                .AppendLine($"Total Capacity Taken: {software.Sum(x => x.CapacityConsumption)} / {hardware.Sum(x => x.MaximumCapacity)}");
            return sb.ToString();
        }
    }
}