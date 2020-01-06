namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class CreateYachtCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public CreateYachtCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.CreateYacht(parameters[0], int.Parse(parameters[1]), parameters[2], int.Parse(parameters[3]));
        }
    }
}
