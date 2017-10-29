namespace Lab.AdvancedCSharp.Bashsoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO;
    using StaticData;

    public class RepositorySorter : IDataSorter
    {
        private readonly ConsoleColor defaultColor = Console.ForegroundColor;

        public void OrderAndTake(Dictionary<string, double> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(wantedData
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(wantedData
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> sortedStudents)
        {
            foreach (var pair in sortedStudents)
            {
                OutputWriter.WriteMessageLine($"{pair.Key} - {pair.Value}", this.defaultColor);
            }
        }
    }
}
