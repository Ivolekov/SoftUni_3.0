using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "Card Deck")
            {
                var ranks = Enum.GetValues(typeof(Rank));
                var suits = Enum.GetValues(typeof(Suit));

                foreach (var rank in ranks)
                {
                    foreach (var suit in suits)
                    {
                        Console.WriteLine($"{rank} of {suit}");
                    }
                }
            }
        }
    }

    public enum Suit
    {
        Clubs,
        Hearts,
        Diamonds,
        Spades
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
