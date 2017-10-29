namespace RecyclingStation.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] commandArgs);
    }
}
