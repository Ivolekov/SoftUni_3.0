namespace Lab.AdvancedCSharp.Bashsoft.IO
{
    using System;

    public static class OutputWriter
    {
        public static void WriteMessage(string message, ConsoleColor color)
        {
            ExecuteWriteAction(Console.Write, message, color);
        }

        public static void WriteMessageLine(string message, ConsoleColor color)
        {
            ExecuteWriteAction(Console.WriteLine, message, color);
        }
        
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }
        
        public static void DisplayException(string message)
        {
            ExecuteWriteAction(Console.WriteLine, message, ConsoleColor.Red);
        } 

        private static void ExecuteWriteAction(Action<string> writeAction, string message, ConsoleColor color)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            writeAction(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
