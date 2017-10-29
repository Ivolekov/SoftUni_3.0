namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using System;
    using Attributes;
    using Exceptions;

    [Alias("help")]
    public class GetHelpCommand : Command
    {
        private const ConsoleColor HelpColor = ConsoleColor.Green;

        public GetHelpCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            OutputWriter.WriteMessageLine($"{new string('_', 100)}", HelpColor);
            OutputWriter.WriteMessageLine($"|{"make directory - mkdir: path ",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"open file - open: path ",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"traverse directory - ls: depth ",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"comparing files - cmp: path1 path2",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"change directory - cdrel: relative path",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"change directory - cdabs: absolute path",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"read students data base - readdb: path",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"drop students data base - dropdb",-98}|", HelpColor);
            OutputWriter.WriteMessageLine(
                $"|{"filter students - filter {courseName} excelent/average/poor  take 2/5/all",-98}|", HelpColor);
            OutputWriter.WriteMessageLine(
                $"|{"order students - order {courseName} ascending/descending take 20/10/all",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"show course info - show {courseName} {studentName}",-98}|", HelpColor);
            OutputWriter.WriteMessageLine(
                $"|{"display data entities - display courses/students ascending/descending",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"download file - download: path (saved in current directory)",-98}|", HelpColor);
            OutputWriter.WriteMessageLine(
                $"|{"download file asynchronously - downloadasync: path (saved in the current directory)",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"|{"get help – help",-98}|", HelpColor);
            OutputWriter.WriteMessageLine($"{new string('_', 100)}", HelpColor);
            OutputWriter.WriteEmptyLine();
        }
    }
}
