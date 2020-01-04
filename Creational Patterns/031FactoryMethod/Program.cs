namespace _031FactoryMethod
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            HiringManager devManager = new DevelopmentManager();
            HiringManager marketingManager = new MarketingManager();

            Console.WriteLine(devManager.TakeInterview());
            Console.WriteLine(marketingManager.TakeInterview());
        }
    }
}
