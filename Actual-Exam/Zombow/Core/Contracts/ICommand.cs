namespace Zombow.Core.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute(IList<string> args);
    }
}