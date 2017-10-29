namespace RecyclingStation.Models.Strategies
{
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Strategy : IStrategy
    {
        private IGarbage garbage;

        public ProcessingData processingData;

        protected Strategy(IGarbage garbage, ProcessingData processingData)
        {
            this.Garbage = garbage;
            this.processingData = new ProcessingData();
        }

        public abstract void EnergyUsed();

        public abstract void CapitalEarned();

        public IGarbage Garbage { get; protected set; }
    }
}
