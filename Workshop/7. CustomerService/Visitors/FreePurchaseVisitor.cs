namespace CustomerService.Visitors
{
    using Contracts;
    using Models;

    public class FreePurchaseVisitor : ICustomerVisitor
    {
        private Purchase purchase;

        public FreePurchaseVisitor(Purchase purchase)
        {
            this.purchase = purchase;
        }

        public void Visit(Customer customer)
        {
            customer.AddFreePurchase(this.purchase);
        }
    }
}
