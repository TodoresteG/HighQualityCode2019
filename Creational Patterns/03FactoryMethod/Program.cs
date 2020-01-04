namespace FactoryMethod
{
    using System;

    public class Program
    {
        public static void Main()
        {
            ICreditUnionFactory factory = new SavingsAcctFactory();

            var cityAcct = factory.GetSavingsAccount("CITY-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citu balance is ${cityAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");
        }
    }
}