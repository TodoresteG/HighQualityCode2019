namespace Zombow.Models.Players.Contracts
{
    using Bows.Contracts;
    using Repositories.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        bool IsAlive { get; }

        IRepository<IBow> BowRepository { get; }

        int LifePoints { get; }

        void TakeLifePoints(int points);
    }
}