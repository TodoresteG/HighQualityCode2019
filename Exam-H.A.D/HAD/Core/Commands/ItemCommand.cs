namespace HAD.Core.Commands
{
    using Contracts;
    using Entities.Items;
    using Utilities;

    using System.Collections.Generic;

    public class ItemCommand : ICommand
    {
        private readonly Dictionary<string, IHero> heroes;

        public ItemCommand(Dictionary<string, IHero> heroes)
        {
            this.heroes = heroes;
        }

        public string Execute(IList<string> arguments)
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
    }
}
