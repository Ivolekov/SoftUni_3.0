namespace RecyclingStation.Models.Strategies
{
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StorableStrategy : Strategy
    {
        private const double PercentOfTotalGarbageVolume = 0.13;
        private const double StorableCapitalMultiplyer = 0.65;

        public StorableStrategy(IGarbage garbage, ProcessingData processingData)
            : base(garbage, processingData)
        {
        }

        public override void EnergyUsed()
        {
            var totalEnergy = (base.Garbage.VolumePerKg * base.Garbage.Weight) * PercentOfTotalGarbageVolume;
            this.processingData.EnergyBalance += totalEnergy;
        }

        public override void CapitalEarned()
        {
            var totalCapitalEarned = (this.Garbage.VolumePerKg * this.Garbage.Weight) * StorableCapitalMultiplyer;
            base.processingData.CapitalBalance += totalCapitalEarned;
        }
    }
}
