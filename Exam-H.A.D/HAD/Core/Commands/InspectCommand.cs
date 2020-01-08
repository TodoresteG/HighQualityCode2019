namespace HAD.Core.Commands
{
    using Contracts;

    using System.Collections.Generic;

    public class InspectCommand : ICommand
    {
        private readonly Dictionary<string, IHero> heroes;

        public InspectCommand(Dictionary<string, IHero> heroes)
        {
            this.heroes = heroes;
        }

        public string Execute(IList<string> arguments)
        {
            string heroName = arguments[0];

            return this.heroes[heroName].ToString();
        }
    }
}
