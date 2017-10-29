namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> wantedData, string comparison, int studentsToTake);
    }
}
