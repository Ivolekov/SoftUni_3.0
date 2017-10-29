using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NMS
{
    class NMS
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string text = string.Empty;
            while (input != "---NMS SEND---")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }
            string delimiter = Console.ReadLine();

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] >= 65 && sb[i] <= 90)
                {
                    var curChar = sb[i].ToString().ToLower();
                    if (curChar[i] < sb[i + 1])
                    {
                        text += sb[i];
                    }
                    else
                    {
                        text += delimiter + sb[i + 1];
                    }
                }
                else
                {
                    if (sb[i] < sb[i + 1])
                    {
                        text += sb[i];
                    }
                    else
                    {
                        text += delimiter + sb[i + 1];
                    }
                }
            }
        }
        Console.WriteLine();
        }
}
