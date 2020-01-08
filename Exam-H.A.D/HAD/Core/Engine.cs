namespace HAD.Core
{
    using Contracts;

    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Engine
    {
        private readonly Dictionary<string, IHero> heroes;

        private bool isRunning = true;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            this.heroes = new Dictionary<string, IHero>();

            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string line = this.reader.ReadLine();
                List<string> arguments = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                string output = this.commandProcessor.Process(this.heroes, arguments);
                this.writer.WriteLine(output);

                this.isRunning = this.ShouldContinue(line);
            }

            //this.writer.Flush();
        }

        private bool ShouldContinue(string line)
        {
            return line != "Quit";
        }
    }
}