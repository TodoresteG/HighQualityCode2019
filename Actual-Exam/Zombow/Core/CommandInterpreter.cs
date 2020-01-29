namespace Zombow.Core
{
    using Commands;
    using Contracts;
    using Models.Bows.Contracts;
    using Models.Hordes.Contracts;
    using Models.Players;
    using Models.Players.Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly List<IPlayer> zombies;
        private readonly IZombieHorde horde;
        private readonly Queue<IBow> bows;
        private readonly MainPlayer mainPlayer;
        private readonly IBowFactory bowFactory;

        public CommandInterpreter(IZombieHorde horde, MainPlayer mainPlayer, IBowFactory bowFactory)
        {
            this.zombies = new List<IPlayer>();
            this.bows = new Queue<IBow>();

            this.horde = horde;
            this.mainPlayer = mainPlayer;
            this.bowFactory = bowFactory;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string commandName = inputParameters[0];
            IList<string> args = inputParameters.Skip(1).ToList();

            string result = string.Empty;
            ICommand command;

            if (commandName == "AddZombie")
            {
                command = new AddZombieCommand(this.zombies);
                result = command.Execute(args);
            }
            else if (commandName == "AddBow")
            {
                command = new AddBowCommand(this.bows, this.bowFactory);
                result = command.Execute(args);
            }
            else if (commandName == "AddBowToPlayer")
            {
                command = new AddBowToPlayerCommand(this.mainPlayer, this.zombies, this.bows);
                result = command.Execute(args);
            }
            else if (commandName == "Fight")
            {
                // TODO: remove args from fight command
                command = new FightCommand(this.mainPlayer, this.zombies, this.horde);
                result = command.Execute(args);
            }

            return result;
        }
    }
}