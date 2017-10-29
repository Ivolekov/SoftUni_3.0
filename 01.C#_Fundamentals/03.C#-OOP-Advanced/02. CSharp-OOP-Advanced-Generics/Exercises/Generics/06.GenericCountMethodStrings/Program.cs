using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenericCountMethodStrings
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> genericList =new List<double>();

            for (int i = 0; i < n; i++)
            {
                double text = double.Parse(Console.ReadLine());
                genericList.Add(text);
            }

            double stringForCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(GenericBox<double>.Compare(genericList, stringForCompare));
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

        public static void Swap<T>(List<GenericBox<T>> list, int firstPosition, int secondPosition)
        {
            GenericBox<T> oldFirstPosition = list[firstPosition];
            list[firstPosition] = list[secondPosition];
            list[secondPosition] = oldFirstPosition;
        }

        public static int Compare<T>(List<T> list, T element )
            where T: IComparable<T>
        {
            int counter = 0;

            foreach (var generic in list)
            {
                if (generic.CompareTo(element)>0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
