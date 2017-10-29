using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CustomStack<string> stack = new CustomStack<string>();
            while (input != "END")
            {
                string[] tokens = input.Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();
                switch (command)
                {
                    case "push":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            stack.Push(tokens[i]);
                        }
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                }
                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] arr;

        public CustomStack()
        {
            arr = new T[0];
        }

        public void Pop()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("No elements");
                return;
            }
            T[] tempCollection = new T[arr.Length - 1];
            for (int i = 0; i < tempCollection.Length; i++)
            {
                tempCollection[i] = arr[i];
            }
            arr = tempCollection;
        }

        public void Push(T element)
        {
            T[] tempCollection = new T[arr.Length + 1];
            arr.CopyTo(tempCollection, 0);
            tempCollection[arr.Length] = element;
            this.arr = tempCollection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                yield return arr[i];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
