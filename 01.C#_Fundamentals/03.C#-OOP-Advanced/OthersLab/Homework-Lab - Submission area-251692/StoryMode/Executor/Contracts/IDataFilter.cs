
using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface IDataFilter
    {
        void PrintFilteredStudents(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake);
    }
}
