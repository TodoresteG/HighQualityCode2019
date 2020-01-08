namespace HAD.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public class CommandProcessor : ICommandProcessor
    {
        private const string CommandSuffix = "Command";

        private readonly IHeroFactory heroFactory;

        public CommandProcessor(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }

        public string Process(Dictionary<string, IHero> heroes, IList<string> arguments)
        {
            string commandName = arguments[0];
            arguments = arguments.Skip(1).ToList();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(ct => ct.Name == commandName + CommandSuffix);

            ICommand command = null;

            if (commandType.Name == "HeroCommand")
            {
                command = Activator.CreateInstance(commandType, new object[] { heroes, this.heroFactory }) as ICommand;
            }
            else
            {
                command = Activator.CreateInstance(commandType, new object[] { heroes }) as ICommand;
            }

            if (command == null)
            {
                throw new ArgumentException("Given command is not supported");
            }

            string result = command.Execute(arguments);

            return result;
        }
    }
}