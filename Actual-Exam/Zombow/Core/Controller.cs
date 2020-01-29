namespace Zombow.Core
{
    using Contracts;
    using Models.Bows;
    using Models.Bows.Contracts;
    using Models.Hordes;
    using Models.Hordes.Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Controller : IController
    {
        private readonly List<IPlayer> zombies;
        private readonly IZombieHorde horde;
        private readonly Queue<IBow> bows;
        private readonly MainPlayer mainPlayer;

        public Controller()
        {
            this.zombies = new List<IPlayer>();
            this.bows = new Queue<IBow>();

            this.mainPlayer = new MainPlayer();
            this.horde = new ZombieHorde();
        }

        public string AddZombie(IList<string> args)
        {
            string name = args[0];

            var zombie = new Zombie(name);
            this.zombies.Add(zombie);

            return $"Successfully added zombie: {zombie.Name}!";
        }

        public string AddBow(IList<string> args)
        {
            string type = args[0];
            string name = args[1];

            IBow bow = null;
            string message;

            if (type == "Takedown")
            {
                bow = new Takedown(name);
            }

            if (type == "Recurve")
            {
                bow = new Recurve(name);
            }

            if (bow == null)
            {
                message = "Invalid bow type!";
            }
            else
            {
                message = $"Successfully added {name} of type: {type}";
                this.bows.Enqueue(bow);
            }

            return message;
        }

        public string AddBowToPlayer(IList<string> args)
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

        public string Fight()
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