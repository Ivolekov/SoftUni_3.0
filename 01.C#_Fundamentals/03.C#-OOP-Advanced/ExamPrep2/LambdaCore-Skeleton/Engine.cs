namespace LambdaCore_Skeleton
{
    using System;

    public class Engine
    {
        private CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
             while (true)
            {
                try
                {
                    var input = Console.ReadLine()
                        .Split(new[] {'@', ':'}, StringSplitOptions.RemoveEmptyEntries);
                    var commnadName = input[0];

                    if (commnadName.Equals("System Shutdown!"))
                    {
                        Environment.Exit(0);
                    }

                    var result = this.commandInterpreter
                        .InterpretCommaned(commnadName, input)
                        .Execute();

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
