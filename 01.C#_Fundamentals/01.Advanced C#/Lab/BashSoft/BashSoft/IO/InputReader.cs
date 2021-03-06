﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage(SessionData.currentPath + "> ");
            string input = Console.ReadLine();
            input = input.Trim();
            CommandInterpreter.InterpredCommand(input);
            while (input != EndCommand)
            {
                if (input == EndCommand)
                {
                    break;
                }
                OutputWriter.WriteMessage(SessionData.currentPath + "> ");
                input = Console.ReadLine();
                input = input.Trim();
                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}
