namespace Zombow.Models.Hordes.Contracts
{
    using Players.Contracts;

    using System.Collections.Generic;

    public interface IZombieHorde
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> zombies);
    }
}