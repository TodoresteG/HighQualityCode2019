namespace BoatRacingSimulator.Models.Engines
{
    public class JetEngine : BoatEngine
    {
        private const int Multiplier = 5;

        public JetEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement)
        {
        }

        // TODO maybe it will be calculated every time
        public override double Output => (this.Horsepower * Multiplier) + this.Displacement;
    }
}
