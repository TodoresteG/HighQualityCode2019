namespace AirCombat.Core
{
    using Contracts;
    using Commands;
    using Entities.AirCrafts.Contracts;
    using Entities.AirCrafts.Factories.Contracts;
    using Entities.Parts.Contracts;
    using Entities.Parts.Factories.Contracts;

    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> defeatedAircrafts;
        private readonly IBattleOperator battleOperator;

        private readonly IAirCraftFactory aircraftFactory;
        private readonly IPartFactory partFactory;

        public CommandInterpreter(IBattleOperator battleOperator, IAirCraftFactory aircraftFactory, IPartFactory partFactory)
        {
            this.battleOperator = battleOperator;
            this.aircraftFactory = aircraftFactory;
            this.partFactory = partFactory;

            this.aircrafts = new Dictionary<string, IAirCraft>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedAircrafts = new List<string>();
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);

            string result = string.Empty;

            switch (command)
            {
                case "AirCraft":
                    ICommand airCraftCommand = new AirCraftCommand(this.aircraftFactory, this.aircrafts);
                    result = airCraftCommand.ExecuteCommand(inputParameters);
                    break;
                case "Part":
                    ICommand partCommand = new PartCommand(this.partFactory, this.aircrafts, this.parts);
                    result = partCommand.ExecuteCommand(inputParameters);
                    break;
                case "Inspect":
                    ICommand inspectCommand = new InspectCommand(this.aircrafts, this.parts);
                    result = inspectCommand.ExecuteCommand(inputParameters);
                    break;
                case "Battle":
                    ICommand battleCommand = new BattleCommand(this.battleOperator, this.defeatedAircrafts, this.aircrafts, this.parts);
                    result = battleCommand.ExecuteCommand(inputParameters);
                    break;
                case "Terminate":
                    ICommand terminateCommand = new TerminateCommand(this.aircrafts, this.defeatedAircrafts, this.parts);
                    result = terminateCommand.ExecuteCommand(inputParameters);
                    break;
            }

            return result;
        }
    }
}