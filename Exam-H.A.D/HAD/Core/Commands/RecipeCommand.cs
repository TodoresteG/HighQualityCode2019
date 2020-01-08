namespace HAD.Core.Commands
{
    using Contracts;
    using Entities.Items;
    using Utilities;

    using System.Linq;
    using System.Collections.Generic;

    public class RecipeCommand : ICommand
    {
        private readonly Dictionary<string, IHero> heroes;

        public RecipeCommand(Dictionary<string, IHero> heroes)
        {
            this.heroes = heroes;
        }

        public string Execute(IList<string> arguments)
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
    }
}
