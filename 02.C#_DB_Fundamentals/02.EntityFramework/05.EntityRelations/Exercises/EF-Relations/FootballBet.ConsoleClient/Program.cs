using FootballBet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBet.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FootballBetContext context = new FootballBetContext();
            context.Database.Initialize(true);
        }
    }
}
