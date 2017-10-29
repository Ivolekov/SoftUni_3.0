namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("cdabs")]
    public class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager ioManager;

        public ChangeAbsolutePathCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length < 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = string.Join(" ", this.Data).Substring(6);
            this.ioManager.ChangeDirectoryAbsolute(absolutePath);
        }
    }
}
