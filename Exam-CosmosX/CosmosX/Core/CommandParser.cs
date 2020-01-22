namespace CosmosX.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            var method = this.reactorManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == command + CommandNameSuffix);

            string result = (string)method.Invoke(this.reactorManager, new object[] { commandArguments });

            return result;
        }
    }
}