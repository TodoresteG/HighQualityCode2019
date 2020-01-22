namespace CosmosX.Core.Contracts
{
    using System.Collections.Generic;

    public interface ICommandParser
    {
        string Parse(IList<string> arguments);
    }
}