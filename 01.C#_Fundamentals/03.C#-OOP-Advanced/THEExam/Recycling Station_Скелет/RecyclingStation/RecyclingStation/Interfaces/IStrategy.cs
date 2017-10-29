namespace RecyclingStation.Interfaces
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IStrategy
    {
        void EnergyUsed();

        void CapitalEarned();

        IGarbage Garbage { get; }
    }
}
