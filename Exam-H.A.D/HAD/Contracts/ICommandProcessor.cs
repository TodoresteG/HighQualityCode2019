namespace HAD.Contracts
{
    using System.Collections.Generic;

    public interface ICommandProcessor
    {
        string Process(Dictionary<string, IHero> heroes, IList<string> arguments);
    }
}