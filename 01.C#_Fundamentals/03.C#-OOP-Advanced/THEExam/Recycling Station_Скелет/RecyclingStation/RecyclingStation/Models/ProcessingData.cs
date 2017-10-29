namespace RecyclingStation.Models
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        private double energyBalance;
        private double capitalBalance;

        public ProcessingData()
        {
            this.EnergyBalance = 0;
            this.CapitalBalance = 0;
        }

        public double EnergyBalance
        {
            get { return this.energyBalance; }
            set { this.energyBalance = value; }
        }

        public double CapitalBalance
        {
            get { return this.capitalBalance; }
            set { this.capitalBalance = value; }
        }
    }
}
