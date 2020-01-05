namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bank = new Bank(100);
            var paypal = new Paypal(200);
            var bitcoin = new Bitcoin(300);

            // Let's prepare a chain like below
            // $bank->$paypal->$bitcoin
            //
            // First priority bank
            // If bank can't pay then paypal
            // If paypal can't pay then bit coin
            bank.SetNext(paypal);
            paypal.SetNext(bitcoin);

            bank.Pay(259);
        }
    }
}
