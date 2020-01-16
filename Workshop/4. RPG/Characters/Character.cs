namespace RPG.Characters
{
    using Contracts;

    public abstract class Character : ICharacter
    {
        protected Character(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public IWeapon Weapon { get; }

        public override string ToString()
        {
            return string.Format("{0} wields weapon {1}",
                this.GetType().Name, this.Weapon.GetType().Name);
        }
    }
}
