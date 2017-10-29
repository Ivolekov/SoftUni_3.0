namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Enums;

    class SystemCore : Core
    {
        private const CoreType Type = CoreType.System;

        public SystemCore(int durability)
            : base(Type, durability)
        {

        }
    }
}
