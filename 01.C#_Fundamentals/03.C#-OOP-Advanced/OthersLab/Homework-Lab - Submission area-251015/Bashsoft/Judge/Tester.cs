namespace Lab.AdvancedCSharp.Bashsoft.Judge
{
    using Contracts;
    using Exceptions;
    using IO;
    using StaticData;
    using System;
    using System.IO;

    public class Tester : IContentComparer
    {
        #region Constants and Readonly Fields

        private const ConsoleColor LogColor = ConsoleColor.Yellow;

        private static readonly ConsoleColor DefaultColor = Console.ForegroundColor;

        #endregion
        
        #region Public Methods

        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            string message = $"User ouput path: {userOutputPath}";
            OutputWriter.WriteMessageLine(message, LogColor);

            message = $"Expected ouput path: {expectedOutputPath}";
            OutputWriter.WriteMessageLine(message, LogColor);
            OutputWriter.WriteEmptyLine();

            try
            {
                string mismatchPath = this.GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = this.GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                this.PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageLine("Files read!", LogColor);
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
        }

        #endregion

        #region Private Methods

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageLine(line, DefaultColor);
                }

                return;
            }

            string message = "Files are identical. There are no mismatches.";
            OutputWriter.WriteMessageLine(message, DefaultColor);
        }

        private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;

            OutputWriter.WriteMessageLine("Comparing files...", LogColor);

            int minOutputLines = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length,
                    expectedOutputLines.Length);
                OutputWriter.DisplayException(
                    ExceptionMessages.DifferentSizeFileComparison);
            }

            string[] mismatches = new string[minOutputLines];

            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                string output;
                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = $"Line {index}: {actualLine}";
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');

            string directoryPath = (indexOf != -1)
                ? expectedOutputPath.Substring(0, indexOf)
                : "";
            string finalPath = Path.Combine(directoryPath, "Mismatches.txt");

            return finalPath;
        }

        #endregion
    }
}
