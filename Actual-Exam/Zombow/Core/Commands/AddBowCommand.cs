namespace Zombow.Core.Commands
{
    using Contracts;
    using Models.Bows.Contracts;

    using System.Collections.Generic;

    public class AddBowCommand : ICommand
    {
        private readonly Queue<IBow> bows;
        private readonly IBowFactory bowFactory;

        public AddBowCommand(Queue<IBow> bows, IBowFactory bowFactory)
        {
            this.bows = bows;
            this.bowFactory = bowFactory;
        }

        public string Execute(IList<string> args)
        {
            string type = args[0];
            string name = args[1];

            IBow bow = this.bowFactory.CreateBow(type, name);

            this.bows.Enqueue(bow);

            return $"Successfully added {bow.Name} of type: {bow.GetType().Name}";
        }
    }
}
