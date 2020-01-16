namespace Skyrim.Contracts
{
    using Items;

    public interface IDragonDeathObserver
    {
        void Update(Weapon weapon);
    }
}
