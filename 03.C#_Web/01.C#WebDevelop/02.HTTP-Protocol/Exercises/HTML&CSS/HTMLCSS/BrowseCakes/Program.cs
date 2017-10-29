using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseCakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string fileContent = File.ReadAllText("browseCakesIndex.html");
            Console.WriteLine(fileContent);
            string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            string desireCake = string.Empty;
            desireCake = getContent.Split('=')[1];
            string[] allCales = File.ReadAllLines(@"database.csv");
            var filteredCakes = allCales.Where(c => c.Contains(desireCake));
            foreach (var cake in filteredCakes)
            {
                var cakeInfo = cake.Split(',');
                string cakeName = cakeInfo[0];
                decimal cakePrice = decimal.Parse(cakeInfo[1]);
                Console.WriteLine($"<br>{cakeName} ${cakePrice}<br>");
            }
        }
    }
}
