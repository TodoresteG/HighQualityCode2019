namespace HAD.Entities.Miscellaneous
{
    using Contracts;
    using Entities.Items;

    using System.Collections.Generic;
    using System.Linq;

    public class HeroInventory : IInventory
    {
        private readonly IDictionary<string, IItem> commonItems;
        private readonly IDictionary<string, IRecipe> recipeItems;

        private bool hasCombined = false;

        public HeroInventory()
        {
            this.commonItems = new Dictionary<string, IItem>();
            this.recipeItems = new Dictionary<string, IRecipe>();
        }

        public long TotalStrengthBonus => this.commonItems.Values.Sum(i => i.StrengthBonus);

        public long TotalAgilityBonus => this.commonItems.Values.Sum(i => i.AgilityBonus);

        public long TotalIntelligenceBonus => this.commonItems.Values.Sum(i => i.IntelligenceBonus);

        public long TotalHitPointsBonus => this.commonItems.Values.Sum(i => i.HitPointsBonus);

        public long TotalDamageBonus => this.commonItems.Values.Sum(i => i.DamageBonus);

        public IReadOnlyCollection<IItem> CommonItems => this.commonItems.Values.ToList().AsReadOnly();

        public void AddCommonItem(IItem item)
        {
            this.commonItems.Add(item.Name, item);
            this.CheckRecipes();
        }

        public void AddRecipeItem(IRecipe recipe)
        {
            this.recipeItems.Add(recipe.Name, recipe);
            this.CheckRecipes();
        }

        private void CheckRecipes()
        {
            IRecipe recipeToRemove = null;

            foreach (var recipe in this.recipeItems.Values)
            {
                var requiredItems = new List<string>(recipe.RequiredItems);

                foreach (var item in this.commonItems.Values)
                {
                    if (requiredItems.Contains(item.Name))
                    {
                        requiredItems.Remove(item.Name);
                    }
                }

                if (requiredItems.Count == 0)
                {
                    recipeToRemove = recipe;
                    this.hasCombined = true;
                    this.CombineRecipe(recipe);
                }
            }

            if (this.recipeItems.Count > 0 && this.hasCombined)
            {
                this.recipeItems.Remove(recipeToRemove.Name);
                this.hasCombined = false;
            }
        }

        private void CombineRecipe(IRecipe recipe)
        {
            for (int i = 0; i < recipe.RequiredItems.Count; i++)
            {
                string item = recipe.RequiredItems[i];
                this.commonItems.Remove(item);
            }

            IItem newItem = new CommonItem(recipe.Name,
                recipe.StrengthBonus,
                recipe.AgilityBonus,
                recipe.IntelligenceBonus,
                recipe.HitPointsBonus,
                recipe.DamageBonus);

            this.commonItems.Add(newItem.Name, newItem);
        }
    }
}