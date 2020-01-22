namespace CosmosX.Core.Contracts
{
    using System.Collections.Generic;

    public interface IManager
    {
        string ReactorCommand(IList<string> arguments);

        string ModuleCommand(IList<string> arguments);

        string ReportCommand(IList<string> arguments);

        string ExitCommand(IList<string> arguments);
    }
}