namespace Zombow.Core.Commands
{
    using Contracts;
    using Models.Hordes.Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    using System.Text;
    using System.Collections.Generic;

    public class FightCommand : ICommand
    {
        private readonly MainPlayer mainPlayer;
        private readonly List<IPlayer> zombies;
        private readonly IZombieHorde horde;

        public FightCommand(MainPlayer mainPlayer, List<IPlayer> zombies, IZombieHorde horde)
        {
            this.mainPlayer = mainPlayer;
            this.zombies = zombies;
            this.horde = horde;
        }

        public string Execute(IList<string> args)
        {
            this.horde.Action(this.mainPlayer, this.zombies);

            int killedZombies = this.zombies.RemoveAll(x => x.IsAlive == false);

            StringBuilder sb = new StringBuilder();

            if (killedZombies == 0 && this.mainPlayer.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Andrew live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Andrew has killed: {killedZombies} zombies!");
                sb.AppendLine($"Left Zombies: {this.zombies.Count}!");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
