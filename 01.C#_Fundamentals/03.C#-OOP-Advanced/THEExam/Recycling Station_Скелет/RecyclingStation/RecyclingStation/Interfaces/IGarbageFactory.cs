namespace RecyclingStation.Interfaces
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IGarbageFactory
    {
        IWaste CreateWaste(string type, string name, double weight, double volume);
    }
}
