using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kermen.Factories;

namespace Kermen
{
    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();
            int counter = 0;
            while (input != "Democracy")
            {
                counter++;
                try
                {
                    HouseHold hauseHold = HauseHoldFactories.CreatHouseHold(input);
                    kermen.Add(hauseHold);
                }
                catch (Exception)
                {

                }

                if (counter % 3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }

                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());
                }

                if (input == "EVN")
                {
                    Console.WriteLine($"Total consumption: {kermen.Sum(x => x.Cunsumation)}");
                }

                input = Console.ReadLine();
            }

            
            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }
}
