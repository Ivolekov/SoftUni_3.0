using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CardRank
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            if (input == "Card Ranks")
            {
                var ranks = Enum.GetValues(typeof(Rank));
                Console.WriteLine("Card Ranks:");
                foreach (var rank in ranks)
                {
                    Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
                }
            }
        }
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}
