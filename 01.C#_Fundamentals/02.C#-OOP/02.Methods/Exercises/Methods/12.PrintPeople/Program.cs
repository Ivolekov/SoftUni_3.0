using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<Person> people = new List<Person>();
            while (line != "END")
            {
                string[] input = line.Split();

                string name = input[0];
                int age = int.Parse(input[1]);
                string occupation = input[2];

                people.Add(new Person(name, age, occupation));
                people.Sort();
                people.ToArray().ToString();
               
                line = Console.ReadLine();
            }
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person : IComparable<Person>
    {
        public string name;
        public int age;
        public string occupation;

        public Person(string name, int age, string occupation)
        {
            this.name = name;
            this.age = age;
            this.occupation = occupation;
        }

        public int CompareTo(Person other)
        {
            if (this.age != other.age)
            {
                return this.age.CompareTo(other.age);
            }
            return other.age.CompareTo(this.age);
        }

        public override string ToString()
        {
            return string.Format($"{name} - age: {age}, occupation: {occupation}");
        }
    }
}
