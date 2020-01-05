namespace ChainOfResponsibility
{
    public class Paypal : Account
    {
        public Paypal(decimal balance)
        {
            this.balance = balance;
        }
    }
}
