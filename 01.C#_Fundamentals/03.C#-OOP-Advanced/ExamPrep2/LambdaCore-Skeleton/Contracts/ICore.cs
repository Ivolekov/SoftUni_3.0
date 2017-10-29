namespace LambdaCore_Skeleton.Contracts
{
    using LambdaCore_Skeleton.Enums;

    public interface ICore
    {
        char Name { get; }

        int MaxDurability { get; }

        void AddFragment(IFragment fragment);

        IFragment RemoveLastFragment();

        int Durability();

        CoreState State { get; }
    }
}
