namespace BoatRacingSimulator.Core
{
    using Interfaces;

    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private const string CommandSuffix = "Command";

        private readonly IBoatSimulatorController controller;

        public Engine(IBoatSimulatorController controller)
        {
            this.controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();

                if (string.IsNullOrEmpty(commandLine))
                {
                    break;
                }

                var tokens = commandLine.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];

                var parameters = tokens.Skip(1).ToArray();

                try
                {
                    var commandName = name + CommandSuffix;

                    var commandType = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == commandName);


                    var command = Activator.CreateInstance(commandType, new object[] { this.controller }) as ICommandHandler;

                    if (command == null)
                    {
                        throw new InvalidOperationException();
                    }

                    string commandResult = command.ExecuteCommand(parameters);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
