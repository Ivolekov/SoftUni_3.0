using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CardSuitd
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "Card Suits")
            {
                var suits = Enum.GetValues(typeof(Suit));
                Console.WriteLine("Card Suits:");
                foreach (var suit in suits)
                {
                    Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
                }
            }
        }
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
