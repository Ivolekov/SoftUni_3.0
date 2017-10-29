namespace ExamPrep.Contracts
{
    public interface IShop
    {
        int Capacity { get; }
        IShop Successor { get; }
    }
}
