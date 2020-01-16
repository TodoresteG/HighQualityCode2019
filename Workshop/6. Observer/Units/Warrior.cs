namespace Skyrim.Units
{
    using Contracts;
    using Items;

    using System.Text;
    using System.Collections.Generic;

    public class Warrior : Unit, IDragonDeathObserver
    {
        public Warrior(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.Inventory = new List<Weapon>();
        }

        public IList<Weapon> Inventory { get; private set; }

        public void Update(Weapon weapon)
        {
            this.Inventory.Add(weapon);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Inventory)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
