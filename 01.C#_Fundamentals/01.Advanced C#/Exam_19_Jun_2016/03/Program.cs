using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            while (input != "Over!")
            {
                if (input == "Over!")
                {
                    break;
                }

                Regex reg = new Regex(string.Format(@"^(\d+)([a-zA-Z]{{{0}}})([^A-Za-z]+)$", n));
                Match match = reg.Match(input);
                string text = match.Groups[2].Value;
                string result = string.Empty;

                string firstDig = match.Groups[1].Value;

                for (int j = 0; j < firstDig.Length; j++)
                {
                    string charNum = firstDig[j].ToString();
                    int num = int.Parse(charNum);
                    if (num < text.Length && text.Length >= 0)
                    {
                        result += text[num];
                    }
                    else
                    {
                        result += " ";
                    }
                }



                string secondDig = match.Groups[3].Value;
                Regex secontReg = new Regex(@"\d+");
                Match secontMatch = secontReg.Match(secondDig);
            
                if (secontMatch.Success)
                {
                    for (int i = 0; i < secondDig.Length; i++)
                    {
                        string charNum = secondDig[i].ToString();
                        int num = int.Parse(charNum);
                        if (num < text.Length && text.Length >= 0)
                        {
                            result += text[num];
                        }
                        else
                        {
                            result += " ";
                        }
                    }
                }
                if (match.Success)
                {
                    Console.WriteLine(match.Groups[2].Value + " == " + result);
                }
                input = Console.ReadLine();
                if (input == "Over!")
                {
                    break;
                }
                n = int.Parse(Console.ReadLine());

            }
        }
    }
}
