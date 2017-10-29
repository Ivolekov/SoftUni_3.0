namespace RecyclingStation.Core.Commands
{
    using RecyclingStation.Attributes;
    using RecyclingStation.Core.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ChangeManagementRequirement:Command
    {
        [Inject]
        private GarbageFactory garbageFactory;

        [Inject]
        private IGarbageProcessor garbageProcessor;

        public ChangeManagementRequirement(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var garbageType = this.Data[3];
            var capitalBalance = this.Data[2];
            var energyBalance = this.Data[3];

            //IWaste garbage = this.garbageFactory
              //.CreateWaste(garageType, garbageName, garbageWeight, garbageVolume);
            //this.garbageProcessor.ProcessWaste(garbage);
            return "Management requirement changed!";
        }
    }
}
