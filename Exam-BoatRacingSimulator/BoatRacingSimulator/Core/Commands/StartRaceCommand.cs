namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class StartRaceCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public StartRaceCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.StartRace();
        }
    }
}
