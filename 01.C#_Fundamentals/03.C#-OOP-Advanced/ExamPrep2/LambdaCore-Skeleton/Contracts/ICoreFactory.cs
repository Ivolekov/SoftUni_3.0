namespace LambdaCore_Skeleton.Contracts
{
    public interface ICoreFactory
    {
        ICore CreateCore(string type, int durability);
    }
}
