namespace HAD.Core
{
    using Contracts;
    using Entities.Items;
    using Utilities;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroManager : IManager
    {
        private readonly IHeroFactory heroFactory;

        private readonly IDictionary<string, IHero> heroes;

        public HeroManager(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;

            this.heroes = new Dictionary<string, IHero>();
        }

        public string AddHero(IList<string> arguments)
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

        public string AddItem(IList<string> arguments)
        {
            string itemName = arguments[0];
            string heroName = arguments[1];
            int strengthBonus = int.Parse(arguments[2]);
            int agilityBonus = int.Parse(arguments[3]);
            int intelligenceBonus = int.Parse(arguments[4]);
            int hitPointsBonus = int.Parse(arguments[5]);
            int damageBonus = int.Parse(arguments[6]);

            IItem newItem = new CommonItem(
                itemName,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus);

            this.heroes[heroName].AddItem(newItem);

            string result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
            return result;
        }

        public string AddRecipe(IList<string> arguments)
        {
            var itemName = arguments[0];
            var heroName = arguments[1];
            var strengthBonus = int.Parse(arguments[2]);
            var agilityBonus = int.Parse(arguments[3]);
            var intelligenceBonus = int.Parse(arguments[4]);
            var hitpointsBonus = int.Parse(arguments[5]);
            var damageBonus = int.Parse(arguments[6]);
            var requiredItems = arguments.Skip(7).ToList();

            IRecipe recipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus,
                                            hitpointsBonus, damageBonus, requiredItems);

            this.heroes[heroName].AddRecipe(recipe);

            var result = string.Format(Constants.RecipeCreateMessage, recipe.Name, heroName);

            return result;
        }

        public string Inspect(IList<string> arguments)
        {
            string heroName = arguments[0];

            return this.heroes[heroName].ToString();
        }

        public string Quit()
        {
            int counter = 1;

            StringBuilder result = new StringBuilder();

            var sortedHeroes = this.heroes
                .Values
                .OrderByDescending(h => h.Strength + h.Intelligence + h.Agility)
                .ThenByDescending(h => h.HitPoints + h.Damage)
                .ToList();

            foreach (var hero in sortedHeroes)
            {
                string itemLine = hero.Items.Count == 0
                    ? "None"
                    : string.Join(", ", hero.Items.Select(i => i.Name));

                result
                    .AppendLine($"{counter}. {hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"###HitPoints: {hero.HitPoints}")
                    .AppendLine($"###Damage: {hero.Damage}")
                    .AppendLine($"###Strength: {hero.Strength}")
                    .AppendLine($"###Agility: {hero.Agility}")
                    .AppendLine($"###Intelligence: {hero.Intelligence}")
                    .AppendLine($"###Items: {itemLine}");

                counter++;
            }

            return result.ToString().TrimEnd();
        }
    }
}