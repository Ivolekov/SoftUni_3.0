using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<BigInteger> stack = new Stack<BigInteger>();
            stack.Push(1);
            stack.Push(1);

            for (int i = 0; i < n-2; i++)
            {
                BigInteger b = stack.Pop();
                BigInteger a = stack.Peek();
                stack.Push(b);
                stack.Push(a + b);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}