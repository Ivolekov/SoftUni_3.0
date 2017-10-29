using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.Сръбско_Unleashed
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            while (input != "End")
            {
                if (input == "End")
                {
                    break;
                }

                Regex reg = new Regex(@"[^a-zA-Z]+\s*@[a-z-A-Z ]+\s[0-9]+\s[0-9]+");
                Match match = reg.Match(input);

                if (match.Success)
                {
                    string[] tokens = input.Split('@');
                    string singer = tokens[0].Trim();
                    Regex regForVanue = new Regex(@"[a-zA-Z ]+\s");
                    Match matchForVenue = regForVanue.Match(tokens[1]);
                    string vanueWithSpace = matchForVenue.Value;
                    string vanue = vanueWithSpace.Trim();
                    Regex regForPrice = new Regex(@"[0-9]+\s[0-9]+");
                    Match matchForPrice = regForPrice.Match(tokens[1]);
                    string[] priceTokens = matchForPrice.Value.Split(' ');
                    int price = int.Parse(priceTokens[0]);
                    int quantity = int.Parse(priceTokens[1]);
                    int totalMoney = price * quantity;

                    if (!data.ContainsKey(vanue))
                    {
                        data[vanue] = new Dictionary<string, int>();
                        data[vanue].Add(singer, totalMoney);
                    }
                    else
                    {
                        if (!data[vanue].ContainsKey(singer))
                        {
                            data[vanue][singer] = totalMoney;
                        }
                        else
                        {
                            data[vanue][singer] += totalMoney;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            

            foreach (var item in data)
            {
                Console.WriteLine("{0}",item.Key);
                var sortedByMOney = item.Value.OrderByDescending(x => x.Value);
                foreach (var deepItem in sortedByMOney)
                {
                    Console.WriteLine("#  {0} -> {1}", deepItem.Key, deepItem.Value);
                }
            }
        }
    }
}
