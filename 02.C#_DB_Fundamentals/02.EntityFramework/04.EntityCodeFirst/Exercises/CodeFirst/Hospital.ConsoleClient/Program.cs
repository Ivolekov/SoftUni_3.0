using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();
            context.Database.Initialize(true);
        }
    }
}
