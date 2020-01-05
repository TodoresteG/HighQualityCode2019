namespace ChainOfResponsibility
{
    public class Bitcoin : Account
    {
        public Bitcoin(decimal balance)
        {
            this.balance = balance;
        }
    }
}
