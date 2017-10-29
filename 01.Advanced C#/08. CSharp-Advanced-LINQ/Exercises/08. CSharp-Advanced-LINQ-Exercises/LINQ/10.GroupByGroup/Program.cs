using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.GroupByGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var person = new List<Person>();

            while (input[0] != "END")
            {
                if (input[0] == "END")
                {
                    break;
                }

                string name = $"{input[0]} {input[1]}";
                int group = int.Parse(input[2]);
                person.Add(new Person(name, group));

                input = Console.ReadLine().Split(' ');
            }

            var result = person.OrderBy(p=>p.Group).GroupBy(p => p.Group);

            foreach (var item in result)
            {
                var nameList = new List<string>();
                Console.Write(item.Key + " - ");

                foreach (var i in item)
                {
                    nameList.Add(i.Name);
                }
                Console.WriteLine(string.Join(", ", nameList));
            }
        }
    }

    public class Person
    {
        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set;}
        public int Group { get; set; }
    }
}
