namespace HAD.Contracts
{
    public interface IHeroFactory
    {
        IHero CreateHero(string heroType, string name);
    }
}
