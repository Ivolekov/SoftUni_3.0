using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface IDataSorter
    {
        void PrintSortedStudents(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake);
    }
}
