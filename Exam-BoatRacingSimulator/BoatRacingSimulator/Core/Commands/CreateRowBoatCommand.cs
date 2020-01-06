namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class CreateRowBoatCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public CreateRowBoatCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.CreateRowBoat(parameters[0], int.Parse(parameters[1]), int.Parse(parameters[2]));
        }
    }
}
