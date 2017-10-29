using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CardPower
{
    public class Program
    {
        static void Main(string[] args)
        {
            string cardName = Console.ReadLine();
            string cardSuit = Console.ReadLine();

            int suit = (int)Enum.Parse(typeof(Rank), cardName);
            int rank = (int)Enum.Parse(typeof(Suit), cardSuit);

            Console.WriteLine($"Card name: {Enum.Parse(typeof(Rank), cardName)} of {Enum.Parse(typeof(Suit), cardSuit)}; Card power: {suit + rank}");
        }
    }

    public class Card
    {
        public Rank rank;
        public Suit suit;

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }
    }

    public enum Suit
    {
        Clubs, 
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

    public enum Rank
    {
        Ace = 14,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,

    }
}
