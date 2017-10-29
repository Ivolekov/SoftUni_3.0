using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Exam.Factory;

namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Component> components = new List<Component>();

            while (input != "System Split")
            {
                try
                {
                    Component component = SystemFactory.CreateSystem(input);
                    components.Add(component);
                }
                catch (Exception)
                {
                }

                if (input == "Analyze()")
                {
                    Analyze analyze = new Analyze();
                    foreach (var component in components)
                    {
                        if (component.Type == "Power" || component.Type == "Heavy")
                        {
                            analyze.hardware.Add((Hardware)component);
                        }

                        if (component.Type == "Express" || component.Type == "Light")
                        {
                            analyze.software.Add((Software)component);
                        }
                    }

                    Console.WriteLine(analyze);
                }

                input = Console.ReadLine();
            }

            if (input == "System Split")
            {
                Console.WriteLine(components.Count);
            }
        }
    }
}
