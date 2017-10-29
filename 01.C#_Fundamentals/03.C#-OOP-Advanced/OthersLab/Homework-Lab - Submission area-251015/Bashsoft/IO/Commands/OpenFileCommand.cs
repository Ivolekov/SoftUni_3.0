namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using System.Diagnostics;
    using System.IO;
    using Attributes;
    using Exceptions;
    using StaticData;

    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            string filePath = Path.Combine(SessionData.CurrentPath, fileName);

            if (File.Exists(filePath))
            {
                Process.Start(filePath);
            }
            else
            {
                throw new InvalidPathException();
            }
        }
    }
}
