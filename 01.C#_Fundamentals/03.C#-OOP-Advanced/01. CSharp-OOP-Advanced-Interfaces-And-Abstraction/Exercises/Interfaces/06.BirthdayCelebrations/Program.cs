using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthdayble> birthdaybles = new List<IBirthdayble>();
            while (input != "End")
            {
                string[] info = input.Split();

                string type = info[0].ToLower();
                string name = info[1];

                switch (type)
                {
                    case "citizen":
                        int age = int.Parse(info[2]);
                        string id = info[3];
                        string birthdate = info[4];
                        Person person = new Person(name, age, id, birthdate);
                        birthdaybles.Add(person);
                        break;
                    case "pet":
                        string birthdatePet = info[2];
                        Pet pet = new Pet(name, birthdatePet);
                        birthdaybles.Add(pet);
                        break;
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var birthdayble in birthdaybles)
            {
                if (birthdayble.isBirthday(year))
                {
                    Console.WriteLine(birthdayble.Birthdate);
                }
            }
        }
    }
}
