using BashSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                string mismathPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismath;
                string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismath);

                PrintOutput(mismatches, hasMismath, mismathPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayExeption(ExceptionMessages.InvalidPath);
            }
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"Mismatches.txt";
            return finalPath;
        }

        private static string[] GetLinesWithPossibleMismatches(
            string[] actualOutputLines,
            string[] ecpectedOutputLines,
            out bool hasMismathc)
        {
            hasMismathc = false;
            string output = string.Empty;

            string[] mismatches = new string[actualOutputLines.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputLines.Length;
            if (actualOutputLines.Length != ecpectedOutputLines.Length)
            {
                hasMismathc = true;
                minOutputLines = Math.Min(actualOutputLines.Length, ecpectedOutputLines.Length);
                OutputWriter.DisplayExeption(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            for (int i = 0; i < minOutputLines; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLines = ecpectedOutputLines[i];

                if (!actualLine.Equals(expectedLines))
                {
                    output = string.Format("Mismatch at line {0} -- expexted: \"{1}\", actual: \"{2}\"", i, expectedLines, actualLine);
                    output += Environment.NewLine;
                    hasMismathc = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }
                mismatches[i] = output;
            }
            return mismatches;
        }

        private static void PrintOutput(string[] mismathes, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismathes)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                try
                {
                    File.WriteAllLines(mismatchPath, mismathes);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayExeption(ExceptionMessages.InvalidPath);
                }

                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismathes.");
        }
    }
}
