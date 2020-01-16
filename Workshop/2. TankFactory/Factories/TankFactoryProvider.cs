namespace TankManufacturer.Factories
{
    using Contracts;
    using Enums;

    using System;
    using System.Collections.Generic;

    public class TankFactoryProvider
    {
        private static Dictionary<TankType, ITankFactory> factories;

        public static TankFactoryProvider InitFactories(TankType tankType) 
        {
            factories = new Dictionary<TankType, ITankFactory>();

            factories.Add(TankType.American, new AmericanTankFactory());
            factories.Add(TankType.German, new GermanTankFactory());
            factories.Add(TankType.Russian, new RussianTankFactory());

            return new TankFactoryProvider();

            //switch (tankType)
            //{
            //    case TankType.American:
            //        return new AmericanTankFactory();
            //    case TankType.German:
            //        return new GermanTankFactory();
            //    case TankType.Russian:
            //        return new RussianTankFactory();
            //    default:
            //        throw new ArgumentException("Given factory is not supported");
            //}
        }

        public ITank CreateTank(TankType tankType)
        {
            // TODO add validation for tankType and fcatories count
            return factories[tankType].CreateTank();
        }
    }
}
