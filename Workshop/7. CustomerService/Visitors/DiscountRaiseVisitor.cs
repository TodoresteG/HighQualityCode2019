namespace CustomerService.Visitors
{
    using Contracts;
    using Models;

    public class DiscountRaiseVisitor : ICustomerVisitor
    {
        public void Visit(Customer customer)
        {
            customer.RaiseDiscount(0.05);
        }
    }
}
