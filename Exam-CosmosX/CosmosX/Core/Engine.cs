using System;
using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
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
            while (isRunning != true)
            {
                string[] tokens = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Exit")
                {
                    isRunning = true;
                }

                try
                {
                    string result = this.commandParser.Parse(tokens);

                    this.writer.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}