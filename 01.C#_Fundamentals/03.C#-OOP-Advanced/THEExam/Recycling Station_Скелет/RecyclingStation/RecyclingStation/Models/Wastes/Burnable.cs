namespace RecyclingStation.Models.Wastes
{
    using RecyclingStation.Enumerations;

    public class Burnable : Garbage
    {
        private const StrategyType Type = StrategyType.Burnable;

        public Burnable(StrategyType type, string name, double volumePerKg, double weight)
            : base(Type, name, volumePerKg, weight)
        {
        }
}
}
