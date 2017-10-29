using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CardCompareTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new SortedSet<Card>();
            for (int i = 0; i < 2; i++)
            {
                string rankInput = Console.ReadLine();
                string suitInput = Console.ReadLine();
                Rank rank = (Rank)Enum.Parse(typeof(Rank), rankInput);
                Suit suit = (Suit)Enum.Parse(typeof(Suit), suitInput);
                Card card = new Card(rank, suit);
                cards.Add(card);
            }
            Console.WriteLine(cards.Last());
        }
    }

    public class Card : IComparable<Card>
    {
        Rank rank;
        Suit suit;
        private int power;

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public int Power
        {
            get { return (int)this.rank + (int)this.suit; }
        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return $"Card name: {this.rank} of {this.suit}; Card power: {this.Power}";
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
        Two = 2,
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
        King,
        Ace
    }
}
