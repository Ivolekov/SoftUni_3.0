using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Citizen> citizens = new List<Citizen>();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string nameOrModel = tokens[0];
                int inputLenght = tokens.Length;

                switch (inputLenght)
                {
                    case 2:
                        string id = tokens[1];
                        Robot robot = new Robot(nameOrModel, id);
                        citizens.Add(robot);
                        break;
                    case 3:
                        int age = int.Parse(tokens[1]);
                        string idPerson = tokens[2];
                        Person person = new Person(nameOrModel, age, idPerson);
                        citizens.Add(person);
                        break;
                }

                input = Console.ReadLine();
            }

            string idForCheck = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.isFakeId(idForCheck))
                {
                    Console.WriteLine(citizen.ID);
                }
            }
        }
    }
}
