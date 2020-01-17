namespace AirCombat.Core.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string ExecuteCommand(IList<string> arguments);
    }
}
