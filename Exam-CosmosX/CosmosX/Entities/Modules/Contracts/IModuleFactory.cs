using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosX.Entities.Modules.Contracts
{
    public interface IModuleFactory
    {
        IModule CreateModule(string type, int id, int additionalParameter);
    }
}
