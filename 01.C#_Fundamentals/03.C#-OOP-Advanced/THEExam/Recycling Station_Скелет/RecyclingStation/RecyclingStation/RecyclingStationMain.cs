namespace RecyclingStation
{
    using RecyclingStation.Core;
    using RecyclingStation.Core.Factories;
    using RecyclingStation.Interfaces;
    using RecyclingStation.Models;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        public static void Main()
        {
            IGarbageFactory garbageFactory = new GarbageFactory();
            IGarbageProcessor garbageProcessor = new GarbageProcessor();
            IProcessingData processingData = new ProcessingData();

            ICommandInterpreter commandInterpreter = 
                new CommandInterpreter(garbageFactory, garbageProcessor, processingData);
            
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
