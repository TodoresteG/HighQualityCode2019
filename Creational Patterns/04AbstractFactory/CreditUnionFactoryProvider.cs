namespace AbstractFactory
{
    public class CreditUnionFactoryProvider
    {
        public static ICreditUnionFactory GetCreditUnionFactory(string accountNo)
        {
            if (accountNo.Contains("CITI")) { return new CitiCreditUnionFactory(); }
            if (accountNo.Contains("NATIONAL")) { return new NationalCreditUnionFactory(); }
            return null;
        }
    }
}