using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddress = Console.ReadLine().Split();
            string fullName = nameAddress[0] + " " + nameAddress[1];
            string address = nameAddress[2];
            Tuple<string, string> personWithNameAndAddress = new Tuple<string, string>(fullName ,address);
            Console.WriteLine(personWithNameAndAddress);

            string[] nameAndBeerAmount = Console.ReadLine().Split();
            string name = nameAndBeerAmount[0];
            int beerAmount = int.Parse(nameAndBeerAmount[1]);
            Tuple<string, int> personDrinkBeer = new Tuple<string, int>(name, beerAmount);
            Console.WriteLine(personDrinkBeer);

            string[] integrDouble = Console.ReadLine().Split();
            int integer = int.Parse(integrDouble[0]);
            double theDouble = double.Parse(integrDouble[1]);
            Tuple<int, double> doubleInteger = new Tuple<int, double>(integer, theDouble);
            Console.WriteLine(doubleInteger);

        }
    }

    public class Tuple<K, V>
    {
        private K key;
        private V value;

        public Tuple(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{this.key} -> {this.value}";
        }
    }
}
