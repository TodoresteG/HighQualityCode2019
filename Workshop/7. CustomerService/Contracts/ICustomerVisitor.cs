namespace CustomerService.Contracts
{
    using Models;

    public interface ICustomerVisitor
    {
        void Visit(Customer customer);
    }
}
