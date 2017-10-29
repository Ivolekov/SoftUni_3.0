using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeerCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();

                int bought = int.Parse(tokens[0]);
                int drank = int.Parse(tokens[1]);
                BeerCounter beer = new BeerCounter(bought, drank);
                BeerCounter.BuyBeer(bought);
                BeerCounter.DrinkBeer(drank);
                input = Console.ReadLine();
            }
            Console.Write(BeerCounter.beerInStock + " ");
            Console.WriteLine(BeerCounter.beersDrankCount);
        }
    }

    public class BeerCounter
    {
        public static int beerInStock;
        public static int beersDrankCount;

        public BeerCounter(int bought, int drank)
        {
            BeerCounter.beerInStock += bought;
            BeerCounter.beersDrankCount += drank;
        }

        public static void BuyBeer(int bottlesCount)
        {
            beerInStock += bottlesCount - bottlesCount;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            beersDrankCount += bottlesCount - bottlesCount;
            beerInStock -= bottlesCount;

        }
    }
}
