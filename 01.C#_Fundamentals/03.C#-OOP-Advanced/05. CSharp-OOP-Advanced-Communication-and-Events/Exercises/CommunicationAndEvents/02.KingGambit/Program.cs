using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KingGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Unit> units = new Dictionary<string, Unit>();

            string kingName = Console.ReadLine();
            King king = new King(kingName);
            units.Add(kingName, king);

            string[] royalName = Console.ReadLine().Split();
            foreach (var royalGuardName in royalName)
            {
                var royalGuard = new RoyalGuards(royalGuardName);
                units.Add(royalGuardName, royalGuard);
            }

            string[] footmanName = Console.ReadLine().Split();
            foreach (var footman in footmanName)
            {
                Footman foot = new Footman(footman);
                units.Add(footman, foot);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Attack King")
                {
                    foreach (var unit in units)
                    {
                        unit.Value.Atack();
                    }
                }

                var tokens = input.Split();

                if (tokens[0] == "Kill")
                {
                    units.Remove(tokens[1]);
                }

                input = Console.ReadLine();
            }
        }
    }
}
