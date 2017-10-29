using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName = Console.ReadLine();
            var firstPlayer = new Player(firstPlayerName);
            string secondPlayerName = Console.ReadLine();
            var secondPlayer = new Player(secondPlayerName);
            while (firstPlayer.hands.Count <= 5)
            {
                string[] cardInfo = Console.ReadLine().Split();
                try
                {
                    Rank rank = (Rank)Enum.Parse(typeof(Rank), cardInfo[0]);
                    Suit suit = (Suit)Enum.Parse(typeof(Suit), cardInfo[2]);
                    Card card = new Card(rank, suit);
                    firstPlayer.hands.Add(card);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (firstPlayer.hands.Count == 5)
                {
                    break;
                }
            }
            while (secondPlayer.hands.Count <= 5)
            {
                string[] cardInfo = Console.ReadLine().Split();
                try
                {
                    Rank rank = (Rank)Enum.Parse(typeof(Rank), cardInfo[0]);
                    Suit suit = (Suit)Enum.Parse(typeof(Suit), cardInfo[2]);
                    Card card = new Card(rank, suit);
                    secondPlayer.hands.Add(card);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (secondPlayer.hands.Count == 5)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }

    public class Player
    {
        public List<Card> hands;
        string name;

        public Player(string name)
        {
            this.name = name;
            this.hands = new List<Card>();
        }
    }

    public class Card : IComparable<Card>
    {
        public Rank rank;
        public Suit suit;
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
