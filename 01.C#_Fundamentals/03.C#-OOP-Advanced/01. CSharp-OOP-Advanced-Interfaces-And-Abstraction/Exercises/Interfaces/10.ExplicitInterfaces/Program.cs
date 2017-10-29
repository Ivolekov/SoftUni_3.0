using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _10.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] citizenInfo = input.Split();
                Citizen citizen = new Citizen(citizenInfo[0]);

                IResident res = citizen;
                IPerson person = citizen;

                person.GetName();
                res.GetName();

                input = Console.ReadLine();
            }
        }
    }

    public interface IResident
    {
        string Name { get; set; }

        string Country { get; set; }

        void GetName();
    }

    public interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        void GetName();
    }

    public class Citizen : IResident, IPerson
    {
        private string name;

        public Citizen(string name)
        {
            this.Name = name;
        }

        string IResident.Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        string IPerson.Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Name { get; private set; }

        public int Age { get; set; }

        public string Country { get; set; }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }

        void IPerson.GetName()
        {
            Console.WriteLine($"{this.Name}");
        }

    }
}
