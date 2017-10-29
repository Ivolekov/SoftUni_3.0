using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_TextEditor
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "1":
                        string textToAdd = input[1];
                        stack.Push(text);
                        text += textToAdd;
                        break;
                    case "2":
                        int count = int.Parse(input[1]);
                        stack.Push(text);
                        text = text.Substring(0, text.Length - count);
                        break;
                    case "3":
                        int show = int.Parse(input[1]);
                        Console.WriteLine(text[show - 1]);
                        break;
                    case "4":
                        text = stack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
