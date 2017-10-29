using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                GenericBox<int> stringGenericBox = new GenericBox<int>(numbers);
                Console.WriteLine(stringGenericBox);
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
    }
}
