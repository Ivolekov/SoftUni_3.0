using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parentheses
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> leftSide = new Stack<char>();
            Queue<char> rightSide = new Queue<char>();

            bool isBalanced = true;

            if (input.Length % 2 != 0)
            {
                isBalanced = false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                char parenthese = input[i];

                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    leftSide.Push(input[i]);
                }
                else if (input[i] == '}' || input[i] == ']' || input[i] == ')')
                {
                    rightSide.Enqueue(input[i]);
                } 
            }

            if (leftSide.Count() == 0 || rightSide.Count() == 0)
            {
                isBalanced = false;
            }

            while (leftSide.Count > 0)
            {
                switch (leftSide.Pop())
                {
                    case '{':
                        if (rightSide.Dequeue() != '}')
                        {
                           isBalanced = false; 
                        }
                        break;
                        case '(':
                        if (rightSide.Dequeue() != ')')
                        {
                           isBalanced = false; 
                        }
                        break;
                        case '[':
                        if (rightSide.Dequeue() != ']')
                        {
                           isBalanced = false; 
                        }
                        break;
                    case ' ':
                        if (rightSide.Dequeue() != ' ')
                        {
                            isBalanced = false;
                        }
                       
                        break;
                    default:
                        isBalanced = false;
                        break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("No");
            }
                
        }
    }
}
