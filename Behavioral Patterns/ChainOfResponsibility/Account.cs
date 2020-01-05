namespace ChainOfResponsibility
{
    using System;

    public abstract class Account
    {
        private Account successor;
        protected decimal balance;

        public void SetNext(Account account) 
        {
            this.successor = account;
        }

        public void Pay(decimal amountToPay) 
        {
            if (this.CanPay(amountToPay))
            {
                Console.WriteLine($"Paid {amountToPay:c} using {this.GetType().Name}");
            }
            else if (this.successor != null)
            {
                Console.WriteLine($"Cannot pay using {this.GetType().Name}. Proceeding...");
                this.successor.Pay(amountToPay);
            }
            else
            {
                throw new ArgumentException("None of the accounts gave enough balance");
            }
        }

        private bool CanPay(decimal amount) 
        {
            return this.balance >= amount;
        }
    }
}
