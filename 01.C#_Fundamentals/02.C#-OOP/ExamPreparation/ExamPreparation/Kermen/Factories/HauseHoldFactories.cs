using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kermen.Factories
{
    class HauseHoldFactories
    {
        public static HouseHold CreatHouseHold(string input)
        {
            string pattern = @"(\w+)\(([\d,\s\.]+)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            if (rgx.IsMatch(input))
            {
                string houseHoldType = matches[0].Groups[1].Value;

                if (houseHoldType == "YoungCouple")
                {
                    return CreateYoungCouple(matches);
                }

                else if (houseHoldType == "YoungCoupleWithChildren")
                {
                    return CreateYoungCoupleWithChildren(matches);
                }

                else if (houseHoldType == "OldCouple")
                {
                    return CreateOldCouple(matches);
                }

                else if (houseHoldType == "AloneYoung")
                {
                    return CreateAloneYoung(matches);
                }

                else if (houseHoldType == "AloneOld")
                {
                    return CreateAloneOLd(matches);
                }

                else
                {
                    throw new ArgumentException();
                }
            }

            throw new ArgumentException("Invalid household");
        }

        private static HouseHold CreateAloneOLd(MatchCollection matches)
        {
            decimal pansion = decimal.Parse(matches[0].Groups[2].Value);

            return new AloneOld(pansion);
        }

        private static HouseHold CreateAloneYoung(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);

            return new AloneYoung(salary, laptopCost);
        }

        private static HouseHold CreateOldCouple(MatchCollection matches)
        {
            decimal[] income = matches[0].Groups[2].Value.Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal pansionOne = income[0];
            decimal pansionTwo = income[1];
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

            return new OldCouple(pansionOne, pansionTwo, tvCost, fridgeCost, stoveCost);
        }

        private static HouseHold CreateYoungCoupleWithChildren(MatchCollection matches)
        {
            decimal[] income = matches[0].Groups[2].Value.Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal salaryOne = income[0];
            decimal salaryTwo = income[1];
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            Child[] children = new Child[matches.Count - 4];

            for (int i = 4; i < matches.Count; i++)
            {
                decimal[] consumtion = matches[0].Groups[2].Value.Split(new[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

                children[i - 4] = new Child(consumtion);
            }

            return new YoungCoupleWithChildren(salaryOne, salaryTwo, tvCost, fridgeCost, laptopCost, children);
        }

        private static HouseHold CreateYoungCouple(MatchCollection matches)
        {
            decimal[] income = matches[0].Groups[2].Value.Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal salaryOne = income[0];
            decimal salaryTwo = income[1];
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            return new YoungCouple(salaryOne, salaryTwo, tvCost, fridgeCost, laptopCost);
        }
    }
}
