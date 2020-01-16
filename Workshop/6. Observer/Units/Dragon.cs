namespace Skyrim.Units
{
    using Contracts;
    using Items;
    using Units;

    using System;
    using System.Collections.Generic;

    public class Dragon : Unit, IDragonSubject
    {
        private List<Warrior> warriorListeners;

        public Dragon(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.warriorListeners = new List<Warrior>();
        }

        public override int HealthPoints 
        {
            get => base.HealthPoints;
            set 
            {
                if (value <= 0)
                {
                    this.Notify();
                }

                base.HealthPoints = value;
            }
        }

        public void Attach(Warrior warrior)
        {
            this.WarriorNullCheck(warrior);

            this.warriorListeners.Add(warrior);
        }

        public void Detach(Warrior warrior)
        {
            this.WarriorNullCheck(warrior);

            if (!this.warriorListeners.Contains(warrior))
            {
                throw new InvalidOperationException("Cannot remove item that is not present in the listeners collection");
            }

            this.warriorListeners.Remove(warrior);
        }

        public void Notify()
        {
            foreach (var warrior in this.warriorListeners)
            {
                warrior.Update(new Weapon(10, 20));
            }
        }

        private void WarriorNullCheck(Warrior warrior) 
        {
            if (warrior == null)
            {
                throw new ArgumentNullException("Warrior cannot be null");
            }
        }
    }
}
