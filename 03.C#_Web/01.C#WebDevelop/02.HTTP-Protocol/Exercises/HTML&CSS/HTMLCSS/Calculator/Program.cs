using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string fileContent = File.ReadAllText("calculator.html");
            Console.WriteLine(fileContent);
            string[] info = Console.ReadLine().Split('&');
            decimal result = 0;
            try
            {
                decimal firstNum = decimal.Parse(info[0].Split('=')[1]);
                string calcOperator = info[1].Split('=')[1];
                decimal secondNum = decimal.Parse(info[2].Split('=')[1]);
                calcOperator = WebUtility.UrlDecode(calcOperator);
                switch (calcOperator)
                {
                    case "+":
                        result = firstNum + secondNum;
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        break;
                    case "*":
                        result = firstNum * secondNum;
                        break;
                    case "/":
                        result = firstNum / secondNum;
                        break;
                    default:
                        throw new Exception();
                }
                Console.WriteLine($"<br>Result: {result}");
            }
            catch (Exception)
            {
                Console.WriteLine("<br>Invalid Sign!");
                throw;
            }
        }
    }
}
