namespace LambdaCore_Skeleton.Repository
{
    using System;
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public class PowerPlantRepository : IRepository
    {
        private Dictionary<char, ICore> cores;
        private char currentCore;
        private int totalDurability;
        private int totalFragmentsCount;

        public PowerPlantRepository()
        {
            this.cores = new Dictionary<char, ICore>();
            this.currentCore = '@';
        }

        public void AddCore(ICore core)
        {
            this.cores.Add(core.Name, core);
        }

        public void RemoveCore(char coreName)
        {
            if (!this.cores.ContainsKey(coreName))
            {
                throw new InvalidOperationException($"Failed to remove Core {coreName}!");
            }
            if (this.currentCore.Equals(coreName))
            {
                this.currentCore = '@';
            }
            this.cores.Remove(coreName);
        }

        public void SetCurrentCore(char coreName)
        {
            if (!this.cores.ContainsKey(coreName))
            {
                throw new InvalidOperationException($"Failed to select Core {coreName}!");
            }

            this.currentCore = coreName;
        }

        public char CurrentCoreName()
        {
            return this.currentCore;
        }

        public bool IsCurrentCoreSet()
        {
            return this.currentCore != '@';
        }

        public void AddFragment(IFragment fragment)
        {
            this.cores[this.currentCore].AddFragment(fragment);
        }

        public IFragment RemoveLastFragment()
        {
            if (!this.IsCurrentCoreSet())
            {
                throw new InvalidOperationException("Failed to detach Fragment!");
            }

            return this.cores[this.currentCore].RemoveLastFragment();
        }
    }
}
