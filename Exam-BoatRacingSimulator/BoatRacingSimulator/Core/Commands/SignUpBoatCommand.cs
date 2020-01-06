namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class SignUpBoatCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public SignUpBoatCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.SignUpBoat(parameters[0]);
        }
    }
}
