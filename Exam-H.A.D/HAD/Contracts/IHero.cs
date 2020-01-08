namespace HAD.Contracts
{
    using System.Collections.Generic;

    public interface IHero
    {
        string Name { get; }

        long Strength { get; }

        long Agility { get; }

        long Intelligence { get; }

        long HitPoints { get; }

        long Damage { get; }

        IReadOnlyCollection<IItem> Items { get; }

        void AddItem(IItem item);

        void AddRecipe(IRecipe recipe);
    }
}