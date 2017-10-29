using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Student : Human
    {
        private string facultyNumber;
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            protected set
            {
                Regex reg = new Regex(@"^[a-zA-Z0-9]+$");
                Match match = reg.Match(value);
                if ((value.Length > 10 || value.Length < 5 || !match.Success))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string FirstName
        {
            get
            {
                return base.FirstName;
            }

            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return base.LastName;
            }

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Faculty number: {this.facultyNumber}");
            return base.ToString() + sb.ToString();
        }
    }
}
