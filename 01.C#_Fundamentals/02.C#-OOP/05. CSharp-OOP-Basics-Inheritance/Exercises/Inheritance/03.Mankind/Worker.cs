using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Worker : Human
    {
        private decimal weeklySalary;
        private int workingHours;
        public Worker(string firstName, string lastName, decimal weeklySalary, int workingHours)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkingHours = workingHours;
        }

        public override string LastName
        {
            get { return base.LastName; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            protected set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weeklySalary = value;
            }
        }

        public int WorkingHours
        {
            get { return this.workingHours; }
            protected set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        private decimal SalaryPerHour()
        {
            decimal result = (this.weeklySalary / 5m) / this.workingHours;
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Week Salary: {this.weeklySalary:F2}")
                .AppendLine($"Hours per day: {this.workingHours:F2}")
                .AppendLine($"Salary per hour: {SalaryPerHour():F2}");
            return base.ToString() + sb.ToString();
        }
    }
}
