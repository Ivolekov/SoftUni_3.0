using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJudge
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            Console.WriteLine("Reading files...");

            string mismathPath = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismath;
            string[] mismatches = GetLinesWithPossibleMismathes(actualOutputLines, expectedOutputLines out hasMismath);

            PrintOutput(mismatches, hasMismath, mismathPath);
            Console.WriteLine("Files read!");
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"Mismatches.txt";
            return finalPath;
        }
    }
}
