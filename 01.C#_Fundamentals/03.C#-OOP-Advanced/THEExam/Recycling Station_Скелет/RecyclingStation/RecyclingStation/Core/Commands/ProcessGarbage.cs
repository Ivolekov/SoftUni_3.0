using RecyclingStation.Core.Factories;

namespace RecyclingStation.Core.Commands
{
    using RecyclingStation.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessGarbage : Command
    {
        [Inject]
        private GarbageFactory garbageFactory;

        [Inject]
        private IGarbageProcessor garbageProcessor;

        public ProcessGarbage(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var garageType = this.Data[4];
            var garbageVolume = double.Parse(this.Data[3]);
            var garbageWeight = double.Parse(this.Data[2]);
            var garbageName = this.Data[1];

           
            this.garbageProcessor.StrategyHolder.AddStrategy(typeof(GarbageFactory),null);
            IWaste garbage = this.garbageFactory
               .CreateWaste(garageType, garbageName, garbageWeight, garbageVolume);
            this.garbageProcessor.ProcessWaste(garbage);

            return $"{garbageWeight:F2} kg of {garbageName} successfully processed!";
        }
    }
}
