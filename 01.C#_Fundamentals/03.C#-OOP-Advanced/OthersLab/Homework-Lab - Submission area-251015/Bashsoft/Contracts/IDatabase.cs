namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    public interface IDatabase : IRequester, IFilteredTaker, ISortedTaker
    {
        void LoadData(string fileName);

        void UnloadData();
    }
}
