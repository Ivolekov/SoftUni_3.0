namespace LambdaCore_Skeleton.Contracts
{
    public interface IRepository
    {
        void AddCore(ICore unit);

        void RemoveCore(char coreName);

        void SetCurrentCore(char coreName);

        bool IsCurrentCoreSet();

        char CurrentCoreName();

        void AddFragment(IFragment fragment);

        IFragment RemoveLastFragment();
    }
}
