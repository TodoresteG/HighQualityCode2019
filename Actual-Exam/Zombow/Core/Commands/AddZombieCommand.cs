namespace Zombow.Core.Commands
{
    using Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    using System.Collections.Generic;

    public class AddZombieCommand : ICommand
    {
        private readonly List<IPlayer> zombies;

        public AddZombieCommand(List<IPlayer> zombies)
        {
            this.zombies = zombies;
        }

        public string Execute(IList<string> args)
        {
            string name = args[0];

            var zombie = new Zombie(name);
            this.zombies.Add(zombie);

            return $"Successfully added zombie: {zombie.Name}!";
        }
    }
}
