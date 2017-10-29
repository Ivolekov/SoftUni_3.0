namespace RecyclingStation.Models
{
    using System.ComponentModel;
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            
            return null;
        }
    }
}
