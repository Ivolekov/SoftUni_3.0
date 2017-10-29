namespace Lab.AdvancedCSharp.Bashsoft.Repository
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using IO;
    using StaticData;

    public class RepositoryFilter : IDataFilter
    {
        private readonly ConsoleColor defaultColor = Console.ForegroundColor;

        public void FilterAndTake(Dictionary<string, double> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                this.FilterAndTake(wantedData, mark => mark >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                this.FilterAndTake(wantedData, mark => mark >= 3.5 && mark < 5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                this.FilterAndTake(wantedData, mark => mark < 3.5, studentsToTake);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            var printedStudents = 0;
            foreach (var pair in wantedData)
            {
                if (printedStudents == studentsToTake)
                {
                    break;
                }

                if (givenFilter(pair.Value))
                {
                    OutputWriter.WriteMessageLine($"{pair.Key} - {pair.Value}", this.defaultColor);
                    printedStudents++;
                }
            }
        }
    }
}
