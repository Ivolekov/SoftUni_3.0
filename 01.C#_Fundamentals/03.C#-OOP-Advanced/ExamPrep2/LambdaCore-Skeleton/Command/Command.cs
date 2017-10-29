namespace LambdaCore_Skeleton.Command
{
    using LambdaCore_Skeleton.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; private set; }

        public abstract string Execute();
    }
}
