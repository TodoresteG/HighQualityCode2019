namespace AirCombat.Core.Commands
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.Parts.Contracts;
    using Entities.Parts.Factories.Contracts;
    using Utils;

    using System.Collections.Generic;

    public class PartCommand : ICommand
    {
        private IPartFactory partFactory;
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IDictionary<string, IPart> parts;

        public PartCommand(IPartFactory partFactory, IDictionary<string, IAirCraft> aircrafts, IDictionary<string, IPart> parts)
        {
            this.partFactory = partFactory;
            this.aircrafts = aircrafts;
            this.parts = parts;
        }

        public string ExecuteCommand(IList<string> arguments)
        {
            string aircraftModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = this.partFactory.CreatePart(partType, model, weight, price, additionalParameter);

            switch (partType)
            {
                case "Arsenal":
                    this.aircrafts[aircraftModel].AddArsenalPart(part);
                    break;
                case "Shell":
                    this.aircrafts[aircraftModel].AddShellPart(part);
                    break;
                case "Endurance":
                    this.aircrafts[aircraftModel].AddEndurancePart(part);
                    break;
            }

            if (part != null)
            {
                this.parts.Add(part.Model, part);
            }

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                aircraftModel);
        }
    }
}
