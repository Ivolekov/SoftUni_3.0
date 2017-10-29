using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unversity.Data;

namespace University.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TPCUniversityContext context = new TPCUniversityContext();
            context.Database.Initialize(true);
        }
    }
}
