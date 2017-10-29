using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(wantedData, x => x >= 5, studentsToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
                    break;
                default:
                    OutputWriter.DisplayExeption(ExceptionMessages.InvalidStudentFilter);
                    break;
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
                double averageScore = userName_Points.Value.Average();
                double percentageOfFullfillments = averageScore / 100;
                double mark = percentageOfFullfillments * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }
    }
}
