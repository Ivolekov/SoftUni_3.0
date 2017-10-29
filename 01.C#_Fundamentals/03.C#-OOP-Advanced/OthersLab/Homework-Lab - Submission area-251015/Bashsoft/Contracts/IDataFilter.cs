namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    using System.Collections.Generic;

    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> wantedData, string wantedFilter, int studentsToTake);
    }
}
