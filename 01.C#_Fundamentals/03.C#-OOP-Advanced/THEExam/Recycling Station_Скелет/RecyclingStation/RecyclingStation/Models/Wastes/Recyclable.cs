namespace RecyclingStation.Models.Wastes
{
    using RecyclingStation.Enumerations;

    public class Recyclable : Garbage
    {
       
        private const StrategyType Type = StrategyType.Recyclable;

        public Recyclable(string name, double volumePerKg, double weight)
            : base(Type, name, volumePerKg, weight)
        {
        }
    }
}
