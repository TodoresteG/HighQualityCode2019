namespace Zombow.Core
{
    using Contracts;
    using IO.Contracts;

    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter interpreter;

        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.interpreter = interpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            var resultList = new List<string>();

            while (this.isRunning)
            {
                var input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Exit")
                {
                    this.isRunning = false;
                    resultList.ForEach(result => this.writer.WriteLine(result));
                }

                try
                {
                    string result = this.interpreter.ProcessInput(input);
                    resultList.Add(result);
                }
                catch (Exception ex)
                {
                    resultList.Add(ex.Message);
                }
            }
        }
    }
}