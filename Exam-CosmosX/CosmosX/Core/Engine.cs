namespace CosmosX.Core
{
    using Contracts;
    using IO.Contracts;
    using Utils;

    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            var commandResults = new List<string>();

            while (this.isRunning)
            {
                try
                {
                    var commandLine = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var result = this.commandParser.Parse(commandLine);

                    commandResults.Add(result);

                    if (commandLine[0] == Constants.ExitCommand)
                    {
                        this.isRunning = false;
                        commandResults.ForEach(r => this.writer.WriteLine(r));
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}