namespace RecyclingStation.Core.Factories
{
    using System;
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageFactory : IGarbageFactory
    {
        private const string NamespacePath = "RecyclingStation.Models.";

        public IWaste CreateWaste(string type, string name, double weight, double volume)
        {
            var garbageFullName = NamespacePath + type;

            Type t = Type.GetType(garbageFullName);
            object[] garbageParameters = new object[] { name, weight, volume };

            IWaste garbage;
            try
            {
                garbage = (IWaste)Activator.CreateInstance(t, garbageParameters);
            }
            catch
            {
                throw new InvalidOperationException("");
            }

            return garbage;
        }
    }
}
