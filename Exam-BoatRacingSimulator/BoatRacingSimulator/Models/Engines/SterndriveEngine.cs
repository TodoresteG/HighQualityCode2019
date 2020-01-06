namespace BoatRacingSimulator.Models.Engines
{
    public class SterndriveEngine : BoatEngine
    {
        private const int Multiplier = 7;

        public SterndriveEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement)
        {
        }

        public override double Output => (this.Horsepower * Multiplier) + this.Displacement;
    }
}
