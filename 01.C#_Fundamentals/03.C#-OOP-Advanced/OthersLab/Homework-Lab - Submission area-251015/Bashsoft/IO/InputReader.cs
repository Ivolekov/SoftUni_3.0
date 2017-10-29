namespace Lab.AdvancedCSharp.Bashsoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Contracts;
    using StaticData;

    public class InputReader : IReader
    {
        #region Constants and Readonly Fields

        private const string EndCommand = "quit";

        private static readonly ConsoleColor DefaultColor = Console.ForegroundColor;

        #endregion
        
        #region Private Fields

        private IInterpreter commandInterpreter;

        #endregion

        #region Constructors

        public InputReader(IInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        #endregion

        #region Public Static Methods

        public static string[] ReadLines()
        {
            var lines = new List<string>();

            string inputLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(inputLine))
            {
                lines.Add(inputLine);
                inputLine = Console.ReadLine();
            }

            return lines.ToArray();
        }

        public static string[] ReadLines(string file)
        {
            var currentReader = Console.In;
            Console.SetIn(new StreamReader(file));

            var lines = ReadLines();
            Console.SetIn(currentReader);

            return lines;
        }

        #endregion

        #region Public Methods

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ", DefaultColor);
                var input = Console.ReadLine()?.Trim();

                if (input == EndCommand)
                {
                    break;
                }

                this.commandInterpreter.InterpretCommand(input);
            }
        } 

        #endregion
    }
}
