namespace BoatRacingSimulator
{
    using Core;
    using Controllers;
    using Database;
    using Interfaces;

    public class Program
    {
        public static void Main()
        {
            BoatSimulatorDatabase db = new BoatSimulatorDatabase();

            IBoatSimulatorController boatSimulatorController = new BoatSimulatorController(db, null);

            var engine = new Engine(boatSimulatorController);
            engine.Run();
        }
    }
}
