namespace AirCombat.Core.Commands
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.Parts.Contracts;

    using System.Collections.Generic;

    public class InspectCommand : ICommand
    {
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IDictionary<string, IPart> parts;

        public InspectCommand(IDictionary<string, IAirCraft> aircrafts, IDictionary<string, IPart> parts)
        {
            this.aircrafts = aircrafts;
            this.parts = parts;
        }

        public string ExecuteCommand(IList<string> arguments)
        {
            string model = arguments[0];

            string result = this.aircrafts.ContainsKey(model) ?
                this.aircrafts[model].ToString() :
                this.parts[model].ToString();

            return result;
        }
    }
}
