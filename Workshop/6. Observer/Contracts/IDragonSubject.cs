namespace Skyrim.Contracts
{
    using Units;

    public interface IDragonSubject
    {
        void Attach(Warrior warrior);

        void Detach(Warrior warrior);

        void Notify();
    }
}
