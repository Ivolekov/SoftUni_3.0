using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06.CustomEnumAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Type type = null;
            if (input == "Rank")
            {
                type = typeof(Rank);
            }
            else
            {
                type = typeof(Suit);
            }
            var attribute = type.GetCustomAttributes();

            foreach (var item in attribute)
            {
                Console.WriteLine(item);
            }
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

    [TypeAttribute("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

    [TypeAttribute("Enumeration", "Rank", "Provides rank constants for a Card class.")]
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

    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        private string type;
        private string category;
        private string description;

        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Type { get; private set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}
