namespace LambdaCore_Skeleton.Models.Cores
{
    using System;
    using LambdaCore_Skeleton.Collection;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;

    public abstract class Core : ICore
    {
        private static int nameIntValue = 64;

        private CoreType coreType;
        private int maxDurability;
        private LStack fragments;
        private int presure;
        private int modifietDurability;

        protected Core(CoreType coreType, int maxDurability)
        {
            nameIntValue++;
            this.coreType = coreType;
            this.MaxDurability = maxDurability;
            this.fragments = new LStack();
            this.Name = (char)nameIntValue;
        }

        public char Name { get; }

        public virtual int MaxDurability
        {
            get
            {
                return this.maxDurability;
            }
            set
            {
                if (value<0)
                {
                    throw new InvalidOperationException("Failed to create Core!");
                }

                this.maxDurability = value;
            }
        }

        public void AddFragment(IFragment fragment)
        {
            this.fragments.Push(fragment);
            this.presure += fragment.PressureAffection;
        }

        public int FragmentCout()
        {
            return this.fragments.Count();
        }

        public IFragment RemoveLastFragment()
        {
            if (this.fragments.Count()<1)
            {
                throw  new InvalidOperationException("Failed to detach Fragment!");
            }
            var fragment  = this.fragments.Pop();
            this.presure -= fragment.PressureAffection;
            return fragment;
        }

        public CoreState State => this.presure > 0 ? CoreState.Critical : CoreState.Normal;

        public int Durability() 
        {
            this.modifietDurability = this.maxDurability - this.presure;

            if (this.modifietDurability<0)
            {
                return 0;
            }
            else if (this.maxDurability>=this.modifietDurability)
            {
                return this.maxDurability;
            }
            return this.modifietDurability;
        }
    }
}
