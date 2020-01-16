namespace CustomerService
{
    using Data;
    using Contracts;
    using Models;
    using Visitors;

    using System;

    public class Program
    {
        static void Main()
        {
            var repository = new CustomerRepository();

            ICustomerVisitor discountRaiseVisitor = new DiscountRaiseVisitor();
            var premiumCustomers = repository.GetPremiumCustomers();

            foreach (var premiumCustomer in premiumCustomers)
            {
                premiumCustomer.Accept(discountRaiseVisitor);
            }

            var freePurchaseVisitor = new FreePurchaseVisitor(new Purchase("SteamOp", 0.0));
            var allCustomers = repository.GetAll();
            foreach (var customer in allCustomers)
            {
                customer.Accept(freePurchaseVisitor);
            }

            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
