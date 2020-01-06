namespace BoatRacingSimulator.Models
{
    using Interfaces;
    using Utility;

    public abstract class BoatEngine : IBoatEngine
    {
        private string model;
        private int horsepower;
        private int displacement;

        public BoatEngine(string model, int horsepower, int displacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        public string Model 
        {
            get { return this.model; }
            set 
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        protected int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsepower = value;
            }
        }

        protected int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }

        public abstract double Output { get; }
    }
}
