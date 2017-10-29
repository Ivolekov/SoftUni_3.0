using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> collection = new ListyIterator<string>();
            while (input!="END")
            {
                string[] tokens = input.Split();
                string command = tokens[0].ToLower();
                switch (command)
                {
                    case "create":
                        List<string> nameCollection = new List<string>();
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            nameCollection.Add(tokens[i]);
                        }
                        collection.Create(nameCollection);
                        break;
                    case "move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "hasnext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "print":
                        try
                        {
                            collection.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    public class ListyIterator<T>
    {
        private List<T> collection;
        private static int index;

        public ListyIterator()
        {
            collection = new List<T>();
            index = 0;
        }

        public void Create(List<T> items)
        {
            this.collection = new List<T>();
            this.collection.AddRange(items);
            index = 0;
        }

        public bool Move()
        {
            if (index < collection.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index == collection.Count - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(collection[index]);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }
    }
}
