namespace RecyclingStation.Models.Wastes
{
    using RecyclingStation.Enumerations;

    public class Storable : Garbage
    {
        private const StrategyType Type = StrategyType.Storable;

        public Storable(StrategyType type, string name, double volumePerKg, double weight) 
            : base(Type, name, volumePerKg, weight)
        {
        }
    }
}
