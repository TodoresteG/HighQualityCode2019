namespace AirCombat.Entities.Parts
{
    using Contracts;

    public class ShellPart : Part, IDefenseModifyingPart
    {
        public ShellPart(string model, double weight, decimal price, int defenceModifier) 
            : base(model, weight, price)
        {
            this.DefenseModifier = defenceModifier;
        }

        // TODO: maybe validation for the prop
        public int DefenseModifier { get; private set; }
    }
}
