namespace RecyclingStation.Models.Strategies
{
    using RecyclingStation.Interfaces;

    public class BurnableStrategy : Strategy
    {
        private const double PercentOfTotalGarbageVolume = 0.8;

        public BurnableStrategy(IGarbage garbage, ProcessingData processingData)
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
            this.processingData.CapitalBalance += 0;
        }
    }
}
