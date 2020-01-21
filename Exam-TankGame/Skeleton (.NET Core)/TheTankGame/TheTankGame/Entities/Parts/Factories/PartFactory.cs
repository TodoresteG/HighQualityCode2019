using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        private const string PartSuffix = "Part";

        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type classType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == partType + PartSuffix);

            IPart part = (IPart)Activator.CreateInstance(classType, model, weight, price, additionalParameter);

            return part;
        }
    }
}
