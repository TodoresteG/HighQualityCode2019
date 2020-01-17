namespace AirCombat.Core.Commands
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.AirCrafts.Factories.Contracts;
    using Utils;

    using System.Collections.Generic;

    public class AirCraftCommand : ICommand
    {
        private IAirCraftFactory aircraftFactory;
        private readonly IDictionary<string, IAirCraft> aircrafts;

        public AirCraftCommand(IAirCraftFactory airCraftFactory, IDictionary<string, IAirCraft> aircrafts)
        {
            this.aircraftFactory = airCraftFactory;
            this.aircrafts = aircrafts;
        }

        public string ExecuteCommand(IList<string> arguments)
        {
            string aircraftType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IAirCraft aircraft = this.aircraftFactory.CreateAirCraft(aircraftType, model, weight, price, attack, defense, hitPoints);

            if (aircraft != null)
            {
                this.aircrafts.Add(aircraft.Model, aircraft);
            }

            return string.Format(
                GlobalConstants.AircraftSuccessMessage,
                aircraftType,
                aircraft.Model);
        }
    }
}
