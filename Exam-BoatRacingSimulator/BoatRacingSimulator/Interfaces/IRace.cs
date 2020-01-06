namespace BoatRacingSimulator.Interfaces
{
    using Models.Boats;

    using System.Collections.Generic;

    public interface IRace
    {
        int Distance { get; }

        int WindSpeed { get; }

        int OceanCurrentSpeed { get; }

        bool AllowsMotorboats { get; }

        Dictionary<string, IBoat> RegisteredBoats { get; }

        void AddParticipant(IBoat boat);

        IList<IBoat> GetParticipants();

        int GetBoatTypeCount(string type);
    }
}
