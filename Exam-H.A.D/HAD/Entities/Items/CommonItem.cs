namespace HAD.Entities.Items
{
    using System.Text;

    public class CommonItem : BaseItem
    {
        public CommonItem(
            string name,
            long strengthBonus,
            long agilityBonus,
            long intelligenceBonus,
            long hitPointsBonus,
            long damageBonus)
            : base(
                name,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus)
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"###Item: {this.Name}");
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }
    }
}