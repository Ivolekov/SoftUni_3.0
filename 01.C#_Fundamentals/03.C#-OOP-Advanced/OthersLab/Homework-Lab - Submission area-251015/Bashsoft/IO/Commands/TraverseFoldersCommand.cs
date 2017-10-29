namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;
    using StaticData;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager ioManager;

        public TraverseFoldersCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.ioManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;

                if (int.TryParse(this.Data[1], out depth))
                {
                    this.ioManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
