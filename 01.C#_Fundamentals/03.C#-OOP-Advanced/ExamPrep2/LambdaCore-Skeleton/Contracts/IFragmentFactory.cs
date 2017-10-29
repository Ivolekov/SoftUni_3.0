namespace LambdaCore_Skeleton.Contracts
{
    public interface IFragmentFactory
    {
        IFragment CreateFragment(string type, string name, int pressure);
    }
}
