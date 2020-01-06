namespace BoatRacingSimulator.Core.Commands
{
    using Enumerations;
    using Interfaces;
    using Utility;

    using System;

    public class CreateBoatEngineCommand : ICommandHandler
    {
        private readonly IBoatSimulatorController controller;

        public CreateBoatEngineCommand(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public string ExecuteCommand(string[] parameters)
        {
            EngineType engineType;

            if (Enum.TryParse(parameters[3], out engineType))
            {
                return this.controller.CreateBoatEngine(
                parameters[0],
                int.Parse(parameters[1]),
                int.Parse(parameters[2]),
                engineType);
            }

            throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
        }
    }
}
