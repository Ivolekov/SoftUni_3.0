namespace RecyclingStation.Core.Commands
{
    using RecyclingStation.Interfaces;

    public abstract class Command  : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract string Execute();
    }
}
