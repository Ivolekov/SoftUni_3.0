using System;
using _03DependencyInversion;

namespace _03.DependencyInversion
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var calculator = new PrimitiveCalculator();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "mode")
                {
                    switch (inputArgs[1])
                    {
                        case "/":
                            IStrategy division = new DevisionStrategy();
                            calculator.ChangeStrategy(division);
                            break;
                        case "*":
                            IStrategy multiply = new MultipllyStrategy();
                            calculator.ChangeStrategy(multiply);
                            break;
                        case "-":
                            IStrategy substract = new SubtractionStrategy();
                            calculator.ChangeStrategy(substract);
                            break;
                        case "+":
                            IStrategy adding = new AdditionStrategy();
                            calculator.ChangeStrategy(adding);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                else
                {
                    int firstOperant = int.Parse(inputArgs[0]);
                    int secondOperant = int.Parse(inputArgs[1]);
                    var result = calculator.PerformCalculation(firstOperant, secondOperant);
                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }
        }
    }
}
