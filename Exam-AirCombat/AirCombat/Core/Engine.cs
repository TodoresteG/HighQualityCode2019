namespace AirCombat.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            try
            {
                while (this.isRunning)
                {
                    var inputLine = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (inputLine[0] == "Terminate")
                    {
                        this.isRunning = false;
                    }

                    var result = this.commandInterpreter.ProcessInput(inputLine);

                    this.writer.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}