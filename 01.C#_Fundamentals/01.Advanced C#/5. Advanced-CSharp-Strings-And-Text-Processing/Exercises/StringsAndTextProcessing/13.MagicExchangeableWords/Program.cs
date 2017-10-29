using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string str1 = elements[0];
            string str2 = elements[1];
            string result = "true";
            Dictionary<char, char> dictionary = new Dictionary<char, char>();

            string longerString = string.Empty;
            string shorterString = string.Empty;

            if (str1.Length >= str2.Length)
            {
                longerString = str1;
                shorterString = str2;
            }
            else
            {
                longerString = str2;
                shorterString = str1;
            }

            for (int i = 0; i < longerString.Length; i++)
            {
                if (i < shorterString.Length)
                {
                    if (!dictionary.ContainsKey(longerString[i]))
                    {
                        dictionary.Add(longerString[i], shorterString[i]);
                    }
                    else
                    {
                        if (dictionary[longerString[i]] != shorterString[i])
                        {
                            result = "false";
                            break;
                        }
                    }
                }
                else
                {
                    if (!dictionary.ContainsKey(longerString[i]))
                    {
                        result = "false";
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
