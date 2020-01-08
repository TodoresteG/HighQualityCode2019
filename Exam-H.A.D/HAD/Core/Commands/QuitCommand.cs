namespace HAD.Core.Commands
{
    using Contracts;

    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class QuitCommand : ICommand
    {
        private readonly Dictionary<string, IHero> heroes;

        public QuitCommand(Dictionary<string, IHero> heroes)
        {
            this.heroes = heroes;
        }

        public string Execute(IList<string> arguments)
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
