using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string fileContent = File.ReadAllText("index.html");
            Console.WriteLine(fileContent);
        }
    }
}
