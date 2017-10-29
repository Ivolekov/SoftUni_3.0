using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string fileContent = File.ReadAllText("login.html");
            Console.WriteLine(fileContent);
            string[] info = Console.ReadLine().Split('&');
            string username = info[0].Split('=')[1];
            string password = info[1].Split('=')[1];
            Console.WriteLine($"<br>Hi {username}, your password is {password}");
        }
    }
}
