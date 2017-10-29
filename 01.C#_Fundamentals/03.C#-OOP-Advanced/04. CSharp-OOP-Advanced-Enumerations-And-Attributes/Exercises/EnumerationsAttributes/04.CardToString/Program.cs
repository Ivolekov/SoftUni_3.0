using System;

namespace _04.CardToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();
            Card card = new Card(rank, suit);
            Console.WriteLine(card);
        }
    }

    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        private string Rank { get; }
        private string Suit { get; }

        public override string ToString()
        {
            int suit = (int)Enum.Parse(typeof(Rank), this.Rank);
            int rank = (int)Enum.Parse(typeof(Suit), this.Suit);

            return $"Card name: {Enum.Parse(typeof(Rank), this.Rank)} of {Enum.Parse(typeof(Suit), this.Suit)}; Card power: {suit + rank}";
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
