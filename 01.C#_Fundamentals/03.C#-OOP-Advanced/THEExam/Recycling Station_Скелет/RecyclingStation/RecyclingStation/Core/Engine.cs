namespace RecyclingStation.Core
{
    using System;
    using RecyclingStation.Interfaces;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
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
                        .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    var commandName = input[0];

                    if (commandName.Equals("TimeToRecycle"))
                    {
                        Environment.Exit(0);
                    }

                    string result = this.commandInterpreter
                        .InterpretCommand(commandName, input)
                        .Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
