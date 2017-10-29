namespace RecyclingStation.Models.Strategies
{
    using RecyclingStation.Interfaces;

    public class RecyclableStrategy : Strategy
    {
        private const double PercentOfTotalGarbageVolume = 0.5;
        private const int ReycleCapitalMultiplyer = 400;

        public RecyclableStrategy(IGarbage garbage, ProcessingData processingData) 
            : base(garbage, processingData)
        {
        }

        public override void EnergyUsed()
        {
            var totalEnergy = (this.Garbage.VolumePerKg * this.Garbage.Weight) * PercentOfTotalGarbageVolume;
            this.processingData.EnergyBalance += totalEnergy;
        }

        public override void CapitalEarned()
        {
            var totalCapitalEarned = ReycleCapitalMultiplyer * this.Garbage.Weight;
            this.processingData.CapitalBalance += totalCapitalEarned;
        }

       
    }
}
