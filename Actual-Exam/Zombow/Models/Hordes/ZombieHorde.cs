namespace Zombow.Models.Hordes
{
    using Contracts;
    using Players.Contracts;

    using System.Collections.Generic;

    public class ZombieHorde : IZombieHorde
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> zombies)
        {
            foreach (var zombie in zombies)
            {
                foreach (var bow in mainPlayer.BowRepository.Models)
                {
                    while (zombie.IsAlive && bow.CanShoot)
                    {
                        zombie.TakeLifePoints(bow.Shoot());
                    }

                    if (!zombie.IsAlive)
                    {
                        break;
                    }
                }
            }

            foreach (var civilPlayer in zombies)
            {
                if (!civilPlayer.IsAlive)
                {
                    continue;
                }

                foreach (var bow in civilPlayer.BowRepository.Models)
                {
                    while (mainPlayer.IsAlive && bow.CanShoot)
                    {
                        mainPlayer.TakeLifePoints(bow.Shoot());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}