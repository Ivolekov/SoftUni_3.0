using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] text = Console.ReadLine().Split(' ');
            string output = "";
            for (int i = 0; i < text.Length; i++)
            {
                string outputWord = "";
                string currentWord = text[i];

                for (int j = 0; j < bannedWords.Length; j++)
                {
                    string ban = bannedWords[j];

                    if (currentWord.IndexOf(ban) != -1)
                    {
                        outputWord += currentWord.Replace(ban, new string('*', ban.Length));
                        outputWord += ' ';
                        break;
                    }
                }

                if (outputWord == "")
                {
                    outputWord += currentWord + ' ';

                }
                output += outputWord;
            }
            Console.WriteLine(output);
        }
    }
}
