namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager ioManager;

        public ChangeRelativePathCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relativePath = this.Data[1];
            this.ioManager.ChangeDirectoryRelative(relativePath);
        }
    }
}
