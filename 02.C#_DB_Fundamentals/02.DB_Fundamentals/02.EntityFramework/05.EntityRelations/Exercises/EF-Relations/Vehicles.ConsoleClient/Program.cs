using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Data;
using Vehicles.Models;

namespace Vehicles.ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            VehicleContext context = new VehicleContext();
            context.Database.Initialize(true);
        }
    }
}
