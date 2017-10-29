namespace LambdaCore_Skeleton.Models.Cores
{
    using System;
    using LambdaCore_Skeleton.Enums;

    class ParaCore : Core
    {
        private const CoreType Type = CoreType.Para;
        private const int DurabilityRatio = 3;

        public ParaCore(int durability)
            : base(Type, durability)
        {
        }

        public override int MaxDurability
        {
            get { return base.MaxDurability; }
            set { base.MaxDurability = value / DurabilityRatio; }
        }
    }
}
