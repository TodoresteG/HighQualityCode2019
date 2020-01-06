namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class CreateSailBoatCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public CreateSailBoatCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.CreateSailBoat(parameters[0], int.Parse(parameters[1]), int.Parse(parameters[2]));
        }
    }
}
