using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    public class Cake
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name + ", " + Price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string fileContent = File.ReadAllText("addCakeIndex.html");
            Console.WriteLine(fileContent);
            string postContent = Console.ReadLine();
            string[] cakeInfo = postContent.Split('&');
            string cakeName = cakeInfo[0].Split('=')[1];
            cakeName = cakeName.Replace('+', ' ');
            decimal cakePrice = decimal.Parse(cakeInfo[1].Split('=')[1]);
            if (cakeName != null)
            {
                Console.WriteLine($"<br>Name: {cakeName}<br>");
                Console.WriteLine($"Price: ${cakePrice}<br>");

                Cake cake = new Cake
                {
                    Name = cakeName,
                    Price = cakePrice
                };
                File.AppendAllText(@"database.csv", cake + "\r\n");
            }
        }
    }
}
