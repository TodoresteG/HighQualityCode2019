﻿namespace HAD.Entities.Heroes
{
    using Contracts;
    using Entities.Miscellaneous;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseHero : IHero
    {
        private long strength;
        private long agility;
        private long intelligence;
        private long hitPoints;
        private long damage;
        private IInventory inventory;

        protected BaseHero(
            string name,
            long strength,
            long agility,
            long intelligence,
            long hitPoints,
            long damage)
        {
            this.Name = name;
            this.Strength = strength;
            this.Agility = agility;
            this.Intelligence = intelligence;
            this.HitPoints = hitPoints;
            this.Damage = damage;

            this.inventory = new HeroInventory();
        }

        public string Name { get; private set; }

        public long Strength
        {
            get => this.strength + this.inventory.TotalStrengthBonus;
            private set => this.strength = value;
        }

        public long Agility
        {
            get => this.agility + this.inventory.TotalAgilityBonus;
            private set => this.agility = value;
        }

        public long Intelligence 
        {
            get => this.intelligence + this.inventory.TotalIntelligenceBonus;
            private set => this.intelligence = value;
        }

        public long HitPoints
        {
            get => this.hitPoints + this.inventory.TotalHitPointsBonus;
            private set => this.hitPoints = value;
        }

        public long Damage 
        {
            get => this.damage + this.inventory.TotalDamageBonus;
            private set => this.damage = value;
        }

        public IReadOnlyCollection<IItem> Items => this.inventory.CommonItems;

        public void AddItem(IItem item) => this.inventory.AddCommonItem(item);

        public void AddRecipe(IRecipe recipe) => this.inventory.AddRecipeItem(recipe);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
                .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
                .AppendLine($"Strength: {this.Strength}")
                .AppendLine($"Agility: {this.Agility}")
                .AppendLine($"Intelligence: {this.Intelligence}")
                .Append("Items:");

            if (this.Items.Count == 0)
            {
                result.Append(" None");
            }
            else
            {
                result.Append(Environment.NewLine);

                foreach (var item in this.Items)
                {
                    result.Append(item);
                }
            }

            return result.ToString().Trim();
        }
    }
}