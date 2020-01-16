namespace TankManufacturer
{
    using Enums;
    using Factories;

    using System;

    class Program
    {
        static void Main()
        {
            var factory = TankFactoryProvider.InitFactories();

            var americanTank = TankFactoryProvider.CreateTank(TankType.American);
            Console.WriteLine(americanTank);

            var germanTank = TankFactoryProvider.CreateTank(TankType.German);
            Console.WriteLine(germanTank);

            var russianTank = TankFactoryProvider.CreateTank(TankType.Russian);
            Console.WriteLine(russianTank);
        }
    }
}
