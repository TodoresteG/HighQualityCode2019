namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class CreatePowerBoatCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public CreatePowerBoatCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.CreatePowerBoat(parameters[0], int.Parse(parameters[1]), parameters[2], parameters[3]);
        }
    }
}
