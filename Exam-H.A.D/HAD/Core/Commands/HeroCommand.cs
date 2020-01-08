namespace HAD.Core.Commands
{
    using Contracts;
    using Utilities;

    using System.Collections.Generic;

    public class HeroCommand : ICommand
    {
        private readonly Dictionary<string, IHero> heroes;
        private readonly IHeroFactory heroFactory;

        public HeroCommand(Dictionary<string, IHero> heroes, IHeroFactory heroFactory)
        {
            this.heroes = heroes;
            this.heroFactory = heroFactory;
        }

        public string Execute(IList<string> arguments)
        {
            string heroName = arguments[0];
            string heroTypeName = arguments[1];

            IHero hero = this.heroFactory.CreateHero(heroTypeName, heroName);

            if (!this.heroes.ContainsKey(heroName))
            {
                this.heroes.Add(heroName, hero);
            }

            string result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
            return result;
        }
    }
}
