using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam.Factory
{
    class SystemFactory
    {
        public static Component CreateSystem(string input)
        {
            string pattern = @"(\w+)\(([\w,\s]+)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            if (rgx.IsMatch(input))
            {
                string componentType = matches[0].Groups[1].Value;

                if (componentType == "RegisterPowerHardware")
                {
                    return RegisterPowerHardware(matches);
                }

                else if (componentType == "RegisterHeavyHardware")
                {
                    return RegisterHeavyHardware(matches);
                }

                else if (componentType == "RegisterLightSoftware")
                {
                    return RegisterLightSoftware(matches);
                }

                else if (componentType == "RegisterExpressSoftware")
                {
                    return RegisterExpressSoftware(matches);
                }

                else
                {
                    throw new ArgumentException();
                }
            }

            throw new ArgumentException("Invalid household");
        }

        private static Component RegisterPowerHardware(MatchCollection matches)
        {
            string[] token = matches[0].Groups[2].Value.Split(new[] {' ', ','},
                StringSplitOptions.RemoveEmptyEntries);
            string name = token[0];
            int capacity = int.Parse(token[1]);
            int memory = int.Parse(token[2]);

            return new Power(name, capacity, memory);
        }

        private static Component RegisterHeavyHardware(MatchCollection matches)
        {
            string[] token = matches[0].Groups[2].Value.Split(new[] {' ', ','},
                StringSplitOptions.RemoveEmptyEntries);
            string name = token[0];
            int capacity = int.Parse(token[1]);
            int memory = int.Parse(token[2]);

            return new Heavy(name, capacity, memory);
        }

        private static Component RegisterLightSoftware(MatchCollection matches)
        {
            string[] token = matches[0].Groups[2].Value.Split(new[] {' ', ','},
                StringSplitOptions.RemoveEmptyEntries);
            string hardwareComponentName = token[0];
            string name = token[1];
            int capacity = int.Parse(token[2]);
            int memory = int.Parse(token[3]);

            return new Light(hardwareComponentName, name, capacity, memory);
        }

        private static Component RegisterExpressSoftware(MatchCollection matches)
        {
            string[] token = matches[0].Groups[2].Value.Split(new[] {' ', ','},
                StringSplitOptions.RemoveEmptyEntries);
            string hardwareComponentName = token[0];
            string name = token[1];
            int capacity = int.Parse(token[2]);
            int memory = int.Parse(token[3]);

            return new Express(hardwareComponentName, name, capacity, memory);
        }
    }
}
