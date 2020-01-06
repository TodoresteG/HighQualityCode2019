namespace BoatRacingSimulator.Core.Commands
{
    using Interfaces;

    public class GetStatisticCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public GetStatisticCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            return this.controller.GetStatistic();
        }
    }
}
