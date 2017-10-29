namespace Executor.Contracts.Repository
{
    using Executor.Repository.Contacts;

    public interface IDatabase : IRequester, IFilteredTaker, IOrderedTaker
    {
        void LoadData(string fileName);

        void UnloadData();
    }
}
