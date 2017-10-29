using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07.ImmutableList
{
    class Program
    {
        static void Main(string[] args)
        {
            Type immutableList = typeof(ImmutableList);
            FieldInfo[] fields = immutableList.GetFields();
            if (fields.Length < 1)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(fields.Length);
            }

            MethodInfo[] methods = immutableList.GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
            if (!containsMethod)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(methods.Length);
            }

        }
    }

    public class ImmutableList
    {
        public List<int> numbers;
        public ImmutableList(List<int> numbers = null)
        {
            if (numbers == null)
            {
                this.numbers = new List<int>(numbers);
            }
            else
            {
                this.numbers = numbers;
            }
        }

        public ImmutableList Get()
        {
            List<int> newNumbres = new List<int>(this.numbers);
            ImmutableList newImmutable = new ImmutableList(newNumbres);
            return newImmutable;
        }
    }
}
