using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                string firstLetter = value.Substring(0, 1);
                if (Char.IsLower(firstLetter, 0))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
                }

                this.firstName = value;

            }
        }

        public  virtual string LastName
        {
            get { return this.lastName; }
            protected set
            {
                string firstLetter = value.Substring(0, 1);
                if (Char.IsLower(firstLetter, 0))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.lastName)}");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.LastName}");
            return sb.ToString();
        }
    }
}
