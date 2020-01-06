namespace BoatRacingSimulator.Models
{
    using Exceptions;
    using Interfaces;
    using Models.Boats;
    using Utility;

    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private int distance;

        public Race(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            this.Distance = distance;
            this.WindSpeed = windSpeed;
            this.OceanCurrentSpeed = oceanCurrentSpeed;
            this.AllowsMotorboats = allowsMotorboats;
            this.RegisteredBoats = new Dictionary<string, IBoat>();
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Distance");
                this.distance = value;
            }
        }

        public int WindSpeed { get; private set; }

        public int OceanCurrentSpeed { get; private set; }

        public bool AllowsMotorboats { get; private set; }

        public Dictionary<string, IBoat> RegisteredBoats { get; }

        public void AddParticipant(IBoat boat)
        {
            if (this.RegisteredBoats.ContainsKey(boat.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            this.RegisteredBoats.Add(boat.Model, boat);
        }

        public IList<IBoat> GetParticipants()
        {
            return new List<IBoat>(this.RegisteredBoats.Values);
        }

        public int GetBoatTypeCount(string type) 
        {
            return this.RegisteredBoats.Values.Where(rb => rb.GetType().Name == type).Count();
        }
    }
}
