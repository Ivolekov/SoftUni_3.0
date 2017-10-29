using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<GenericBox<int>> intGenericBoxs = new List<GenericBox<int>>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                GenericBox<int> intGenericBox = new GenericBox<int>(number);
                intGenericBoxs.Add(intGenericBox);
            }

            int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstPositions = positions[0];
            int secondPosition = positions[1];

            GenericBox<string>.Swap(intGenericBoxs, firstPositions, secondPosition);

            foreach (var intGenericBox in intGenericBoxs)
            {
                Console.WriteLine(intGenericBox);
            }
        }
    }

    public class GenericBox<T>
    {
        private T type;

        public GenericBox(T type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return $"{this.type.GetType().FullName}: {this.type}";
        }

        public static void Swap<T>(List<GenericBox<T>> list, int firstPosition, int secondPosition )
        {
            GenericBox<T> oldFirstPosition = list[firstPosition];
            list[firstPosition] = list[secondPosition];
            list[secondPosition] = oldFirstPosition;
        }
    }
}
