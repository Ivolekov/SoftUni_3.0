using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.FoodShortage.Models;

namespace _07.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Human> humans = new List<Human>();

            for (int i = 0; i < n; i++)
            {
                string[] citizenInfo = Console.ReadLine().Split();

                string name = citizenInfo[0];
                int age = int.Parse(citizenInfo[1]);
                int citizenLenght = citizenInfo.Length;

                switch (citizenLenght)
                {
                    case 4:
                        string id = citizenInfo[2];
                        string birthdate = citizenInfo[3];
                        Citizen citizen = new Citizen(name, age, id, birthdate);
                        humans.Add(citizen);
                        break;
                    case 3:
                        string group = citizenInfo[2];
                        Rebel rebel = new Rebel(name, age, group);
                        humans.Add(rebel);
                        break;
                }
            }

            string buyerName = Console.ReadLine();

            while (buyerName != "End")
            {

                humans.Find(h=>h.Name==buyerName)?.BuyFood();
                buyerName = Console.ReadLine();
            }
            int foodQuantity = 0;

            humans.ForEach(x => foodQuantity += x.Food);
            Console.WriteLine(foodQuantity);
        }
    }
}
