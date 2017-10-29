using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                family.AddMember(person);

            }
            Console.WriteLine($"{family.GetOldestMember().name} {family.GetOldestMember().age}");
        }
    }

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public class Family
    {
        public List<Person> persons;

        public Family()
        {
            this.persons = new List<Person>();
        }

        public void AddMember(Person member)
        {
            persons.Add(member);
        }

        public Person GetOldestMember()
        {
            Person result = persons.OrderByDescending(x => x.age).First();
            return result;
        }
    }
}
