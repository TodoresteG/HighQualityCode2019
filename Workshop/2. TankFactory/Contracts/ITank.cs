namespace TankManufacturer.Contracts
{
    public interface ITank
    {
        string Model { get; }

        double Speed { get; }

        int AttackDamage { get; }
    }
}
