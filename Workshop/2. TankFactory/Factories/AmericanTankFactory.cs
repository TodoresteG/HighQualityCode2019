namespace TankManufacturer.Factories
{
    using Contracts;
    using Units;

    public class AmericanTankFactory : ITankFactory
    {
        public ITank CreateTank()
        {
            return new Tank("M1 Abrams", 5.4, 120);
        }
    }
}
