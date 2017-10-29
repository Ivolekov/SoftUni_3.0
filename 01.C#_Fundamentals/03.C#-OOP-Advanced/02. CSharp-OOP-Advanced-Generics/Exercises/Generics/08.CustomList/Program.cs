using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commnads = input.Split();

                string command = commnads[0].ToLower();

                switch (command)
                {
                    case "add":
                        string forAdd = commnads[1];
                        GenericList<string>.Add(forAdd);
                        break;
                    case "remove":
                        int forRemove = int.Parse(commnads[1]);
                        GenericList<string>.Remove(forRemove);
                        break;
                    case "max":
                        Console.WriteLine(GenericList<string>.Max(GenericList<string>.list));
                        break;
                    case "min":
                        Console.WriteLine(GenericList<string>.Min(GenericList<string>.list));
                        break;
                    case "greater":
                        string elemnet = commnads[1];
                        Console.WriteLine(GenericList<string>.CountGreaterThan(GenericList<string>.list, elemnet));
                        break;
                    case "swap":
                        int firstposition = int.Parse(commnads[1]);
                        int secondposition = int.Parse(commnads[2]);
                        GenericList<string>.Swap(GenericList<string>.list, firstposition, secondposition);
                        break;
                    case "contains":
                        string contains = commnads[1];
                        Console.WriteLine(GenericList<string>.Contains(contains));
                        break;
                    case "sort":
                        GenericList<string>.Sort(GenericList<string>.list);
                        break;
                    case "print":
                        GenericList<string>.Print();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    public class GenericList<T>
    {
        public static List<T> list = new List<T>();

        public static void Add(T element)
        {
            list.Add(element);
        }

        public static void Remove(int index)
        {
            list.RemoveAt(index);
        }

        public static bool Contains(T element)
        {
            if (list.Contains(element))
            {
                return true;
            }
            return false;
        }

        public static void Swap<T>(List<T> list, int firstPosition, int secondPosition)
        {
            T oldFirstPosition = list[firstPosition];
            list[firstPosition] = list[secondPosition];
            list[secondPosition] = oldFirstPosition;
        }

        public static int CountGreaterThan<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static T Max<T>(List<T> list)
            where T : IComparable<T>
        {
            T element = list[0];

            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    element = generic;
                }
            }

            return element;
        }

        public static T Min<T>(List<T> list)
            where T : IComparable<T>
        {
            T element = list[0];

            foreach (var generic in list)
            {
                if (generic.CompareTo(element) < 0)
                {
                    element = generic;
                }
            }

            return element;
        }

        public static void Print()
        {
            Console.WriteLine(string.Join("\n", list));
        }

        public static void Sort<T>(List<T> list )
        {
            list.Sort();
        }
    }
}
