namespace BoatRacingSimulator.Controllers
{
    using Database;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Models.Boats;
    using Models.Engines;
    using Utility;

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;

            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
            }

            this.Database.Engines.Add(engine);

            return string.Format(Constants.EngineBoatCreatedMessage, model, horsepower, displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);

            this.Database.Boats.Add(boat);

            return string.Format(Constants.RowBoatCreatedMessage, model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);

            this.Database.Boats.Add(boat);

            return string.Format(Constants.SailBoatCreatedMessage, model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel);

            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel);

            IBoat boat = new PowerBoat(model, weight, new List<IBoatEngine>() { firstEngine, secondEngine });

            this.Database.Boats.Add(boat);

            return string.Format(Constants.PowerBoatCreatedMessage, model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine engine = this.Database.Engines.GetItem(engineModel);

            IBoat boat = new Yacht(model, weight, cargoWeight, engine);

            this.Database.Boats.Add(boat);

            return string.Format(Constants.YachtCreatedMessage, model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }

            this.CurrentRace = race;

            return string.Format(Constants.SuccessfulOpenRaceMessage, distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            this.ValidateRaceIsSet();

            IBoat boat = this.Database.Boats.GetItem(model);

            if (!this.CurrentRace.AllowsMotorboats && boat is Yacht || !this.CurrentRace.AllowsMotorboats && boat is PowerBoat)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);

            return string.Format(Constants.BoatIsSignedSuccessful, model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();

            var participants = this.CurrentRace.GetParticipants();
            var testParticipants = this.CurrentRace.GetParticipants().ToList();

            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);

            var second = this.FindFastest(participants);
            participants.Remove(second.Value);

            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            if (this.GetFinalResultForParticipant(first) == "Did not finish!" &&
                this.GetFinalResultForParticipant(second) == "Did not finish!" &&
                this.GetFinalResultForParticipant(third) == "Did not finish!")
            {
                first = new KeyValuePair<double, IBoat>(first.Key, testParticipants[0]);
                second = new KeyValuePair<double, IBoat>(second.Key, testParticipants[1]);
                third = new KeyValuePair<double, IBoat>(third.Key, testParticipants[2]);
            }

            var result = new StringBuilder();

            result.AppendLine(string.Format(Constants.FirstPlaceMessage, 
                first.Value.GetType().Name, 
                first.Value.Model,
                this.GetFinalResultForParticipant(first)));

            result.AppendLine(string.Format(
                Constants.SecondPlaceMessage,
                second.Value.GetType().Name,
                second.Value.Model,
                this.GetFinalResultForParticipant(second)));

            result.AppendLine(string.Format(
                Constants.ThirdPlaceMessage,
                third.Value.GetType().Name,
                third.Value.Model,
                this.GetFinalResultForParticipant(third)));

            this.CurrentRace = null;

            return result.ToString().TrimEnd();
        }

        public string GetStatistic()
        {
            var sb = new StringBuilder();

            var registeredBoats = this.CurrentRace.GetParticipants();

            var percentageForOneBoat = 100.00 / registeredBoats.Count;

            var distinctedParticipants = registeredBoats
                .OrderBy(rb => rb.Model)
                .Select(rb => rb.GetType().Name)
                .Distinct();

            foreach (var boatType in distinctedParticipants)
            {
                var boatCount = this.CurrentRace.GetBoatTypeCount(boatType);

                var percentageForBoatsFromSameType = this.GetPercenatgeForBoatType(boatType, boatCount, percentageForOneBoat);

                if (!String.IsNullOrEmpty(percentageForBoatsFromSameType))
                {
                    sb.AppendLine(percentageForBoatsFromSameType);
                }
            }
;
            return sb.ToString().TrimEnd();
        }

        private string GetPercenatgeForBoatType(string boatType, int boatCount, double percentageForOneBoat) 
        {
            if (boatCount > 0)
            {
                return $"{boatType} -> {boatCount * percentageForOneBoat:f2}%";
            }

            return "";
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = double.MaxValue;
            double bestTimeNegative = double.MinValue;

            IBoat winner = null;
            IBoat slowestWinner = null;

            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);

                var time = this.CurrentRace.Distance / speed;

                if (time < bestTime && time > 0)
                {
                    bestTime = time;
                    winner = participant;
                }
                else if (time > bestTimeNegative && time < 0)
                {
                    bestTimeNegative = time;
                    slowestWinner = participant;
                }
                else if (participants.Count == 1)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            if (bestTime == double.MaxValue)
            {
                bestTime = bestTimeNegative;
                winner = slowestWinner;
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }

        private string GetFinalResultForParticipant(KeyValuePair<double, IBoat> participant) 
        {
            return participant.Key < 0 || Double.IsInfinity(participant.Key) ? "Did not finish!" : participant.Key.ToString("0.00") + " sec";
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }
    }
}
