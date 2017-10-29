using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            var result = persons.OrderBy(p => p.Name);

            foreach (var person in result)
            {
                if (person.Age > 30)
                {
                    Console.WriteLine("{0} - {1}", person.Name, person.Age);
                }
            }
            //Console.WriteLine();
        }
    }

    public class Person
    {
        public string name;
        public int age;



        public Person() : this("No name", 1)
        {
        }

        public Person(int age) : this("No name", age)
        {
            this.Name = "No name";
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Age);
        }
    }
}
