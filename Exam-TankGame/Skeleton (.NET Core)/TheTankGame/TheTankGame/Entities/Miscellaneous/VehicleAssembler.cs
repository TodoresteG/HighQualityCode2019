namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();

        public double TotalWeight
                         => this.ArsenalParts.Sum(p => p.Weight) +
                            this.ShellParts.Sum(p => p.Weight) +
                            this.EnduranceParts.Sum(p => p.Weight);

        public decimal TotalPrice
                         => this.ArsenalParts.Sum(p => p.Price) +
                            this.ShellParts.Sum(p => p.Price) +
                            this.EnduranceParts.Sum(p => p.Price);

        public long TotalAttackModification
             => this.ArsenalParts.Sum(p => p.AttackModifier);

        public long TotalDefenseModification
             => this.ShellParts.Sum(p => p.DefenseModifier);

        public long TotalHitPointModification
             => this.ShellParts.Sum(p => p.DefenseModifier);

        public void AddArsenalPart(IPart part)
        {
            IAttackModifyingPart arsenalPart = part as IAttackModifyingPart;

            this.arsenalParts?.Add(arsenalPart);
        }

        public void AddShellPart(IPart part)
        {
            IDefenseModifyingPart shellPart = part as IDefenseModifyingPart;

            this.shellParts?.Add(shellPart);
        }

        public void AddEndurancePart(IPart part)
        {
            IHitPointsModifyingPart endurancePart = part as IHitPointsModifyingPart;

            this.enduranceParts?.Add(endurancePart);
        }
    }
}