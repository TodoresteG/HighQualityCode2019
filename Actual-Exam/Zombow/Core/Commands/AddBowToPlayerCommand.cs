namespace Zombow.Core.Commands
{
    using Contracts;
    using Models.Bows.Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class AddBowToPlayerCommand : ICommand
    {
        private readonly MainPlayer mainPlayer;
        private readonly List<IPlayer> zombies;
        private readonly Queue<IBow> bows;

        public AddBowToPlayerCommand(MainPlayer mainPlayer, List<IPlayer> zombies, Queue<IBow> bows)
        {
            this.mainPlayer = mainPlayer;
            this.zombies = zombies;
            this.bows = bows;
        }

        public string Execute(IList<string> args)
        {
            string name = args[0];
            string mainPlayerName = this.mainPlayer.Name;

            if (this.bows.Count == 0)
            {
                return "There are no bows in the queue!";
            }

            if (name == mainPlayerName)
            {
                var playerBow = this.bows.Dequeue();
                this.mainPlayer.BowRepository.Add(playerBow);
                return $"Successfully added {playerBow.Name} to the Main Player: {this.mainPlayer.Name}";
            }

            var player = this.zombies.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return $"Zombie with that name doesn't exist!";
            }

            var currentBow = this.bows.Dequeue();
            player.BowRepository.Add(currentBow);
            return $"Successfully added {currentBow.Name} to the Zombie: {player.Name}";
        }
    }
}
