namespace AirCombat.Core.Commands
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.Parts.Contracts;
    using Utils;

    using System.Linq;
    using System.Collections.Generic;

    public class BattleCommand : ICommand
    {
        private readonly IBattleOperator battleOperator;

        private readonly IList<string> defeatedAircrafts;
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IDictionary<string, IPart> parts;

        public BattleCommand(IBattleOperator battleOperator, 
                                IList<string> defeatedAircrafts,
                                IDictionary<string, IAirCraft> aircrafts,
                                IDictionary<string, IPart> parts)
        {
            this.battleOperator = battleOperator;
            this.defeatedAircrafts = defeatedAircrafts;
            this.aircrafts = aircrafts;
            this.parts = parts;
        }

        public string ExecuteCommand(IList<string> arguments)
        {
            string attackerAircraftModel = arguments[0];
            string targetAircraftModel = arguments[1];

            string winnerAircraftModel = this.battleOperator.Battle(this.aircrafts[attackerAircraftModel], this.aircrafts[targetAircraftModel]);

            if (winnerAircraftModel.Equals(attackerAircraftModel))
            {
                this.aircrafts[targetAircraftModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.aircrafts.Remove(targetAircraftModel);
                this.defeatedAircrafts.Add(targetAircraftModel);
            }
            else
            {
                this.aircrafts[attackerAircraftModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.aircrafts.Remove(attackerAircraftModel);

                this.defeatedAircrafts.Add(attackerAircraftModel);
            }

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerAircraftModel,
                targetAircraftModel,
                winnerAircraftModel);
        }
    }
}
