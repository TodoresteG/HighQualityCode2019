namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class OpenRaceCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public OpenRaceCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller
                .OpenRace(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]), bool.Parse(parameters[3]));
        }
    }
}
