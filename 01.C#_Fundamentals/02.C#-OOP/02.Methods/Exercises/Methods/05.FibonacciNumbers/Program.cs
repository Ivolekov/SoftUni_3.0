using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startPosition = int.Parse(Console.ReadLine());
            int endPosition = int.Parse(Console.ReadLine());
            Fibunacci fibN =new Fibunacci(endPosition);
            Console.WriteLine(String.Join(", ",fibN.GetNumbersInRange(startPosition,endPosition)));
        }
    }

    public class Fibunacci
    {
        List<long> fibList = new List<long>();
        public Fibunacci(long n)
        {
            List<long> resultList = new List<long>();
            long a = 0;
            long b = 1;
            resultList.Add(a);
            resultList.Add(b);
            long c = 0;
            for (int i = 0; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                resultList.Add(c);
            }
            this.fibList = resultList;
        }

        public List<long> GetNumbersInRange(int startPos, int endPos)
        {
            List<long> numbersInRange = new List<long>();
            for (int i = startPos; i < endPos; i++)
            {
                numbersInRange.Add(fibList[i]);
            }
            return numbersInRange;
        }
    }
}
