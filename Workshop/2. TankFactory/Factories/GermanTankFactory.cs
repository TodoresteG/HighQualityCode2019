namespace TankManufacturer.Factories
{
    using Contracts;
    using Units;

    public class GermanTankFactory : ITankFactory
    {
        public ITank CreateTank()
        {
            return new Tank("Tiger", 4.5, 120);
        }
    }
}
