namespace HAD.Entities.Items
{
    using Contracts;

    using System.Collections.Generic;

    public class RecipeItem : BaseItem, IRecipe
    {
        private List<string> requiredItems;

        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems) 
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            this.requiredItems = requiredItems;
        }

        public IReadOnlyList<string> RequiredItems => this.requiredItems.AsReadOnly();
    }
}
