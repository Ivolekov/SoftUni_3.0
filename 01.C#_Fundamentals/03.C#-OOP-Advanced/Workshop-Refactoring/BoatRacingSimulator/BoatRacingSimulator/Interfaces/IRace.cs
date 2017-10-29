namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.Boats;

    public interface IRace
    {
        int Distance { get; }

        int WindSpeed { get; }

        int OceanCurrentSpeed { get; }

        bool AllowsMotorboats { get; }

        void AddParticipant(IBoat boat);

        IList<IBoat> GetParticipants();
    }
}
