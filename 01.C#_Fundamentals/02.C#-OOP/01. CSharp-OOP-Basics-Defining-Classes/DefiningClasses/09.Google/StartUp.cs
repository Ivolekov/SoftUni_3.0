using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string command = tokens[1];

                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, new Person(personName));
                }

                switch (command)
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        decimal salary = decimal.Parse(tokens[4]);
                        people[personName].company = new Company(companyName, department, salary);
                        break;
                    case "pokemon":
                        string pokemonName = tokens[2];
                        string pokemonType = tokens[3];
                        people[personName].pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        break;
                    case "parents":
                        string parentName = tokens[2];
                        string parentBirthday = tokens[3];
                        people[personName].parents.Add(new Parent(parentName, parentBirthday));
                        break;
                    case "children":
                        string childrenName = tokens[2];
                        string childrenBirthday = tokens[3];
                        people[personName].childrens.Add(new Children(childrenName, childrenBirthday));
                        break;
                    case "car":
                        string model = tokens[2];
                        int speed = int.Parse(tokens[3]);
                        people[personName].car = new Car(model, speed);
                        break;
                }

                input = Console.ReadLine();
            }

            string person = Console.ReadLine();
            Console.WriteLine(people[person]);
        }
    }
}
