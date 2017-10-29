namespace LambdaCore_Skeleton.Factories
{
    using System;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Models.Cores;

    public class CoreFactory : ICoreFactory
    {
        private const string Namespace = "LambdaCore_Skeleton.Models.Cores.";
        private const string Text = "Core";

        public ICore CreateCore(string type, int durability)
        {
            var coreFullName = Namespace + type + Text;
            Type myType = Type.GetType(coreFullName);
            object[] coreParams = new object[] {durability};
            ICore core;
            try
            {
                core = (Core)Activator.CreateInstance(myType, coreParams);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Faild to create Core!");
            }

            return core;
        }
    }
}
