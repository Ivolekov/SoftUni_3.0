namespace RecyclingStation.Interfaces
{
    using RecyclingStation.Enumerations;
    using RecyclingStation.WasteDisposal.Interfaces;
    public interface IGarbage : IWaste
    {
        StrategyType Type { get; }
    }
}
