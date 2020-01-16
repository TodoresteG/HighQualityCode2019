namespace CustomerService.Models
{
    using Contracts;

    using System.Text;
    using System.Collections.Generic;

    public class Customer
    {
        private const double DefaultDiscount = 0.0;

        public Customer(string name)
        {
            this.Name = name;
            this.Purchases = new HashSet<Purchase>();
            this.Discount = DefaultDiscount;
        }

        public string Name { get; set; }

        public ISet<Purchase> Purchases { get; set; }

        public double Discount { get; set; }

        public void RaiseDiscount(double amount)
        {
            this.Discount += amount;
        }

        public void AddFreePurchase(Purchase purchase)
        {
            this.Purchases.Add(purchase);
        }

        public void Accept(ICustomerVisitor customerVisitor) 
        {
            customerVisitor.Visit(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Customer {this.Name} has discount - {this.Discount} and Purchases - {this.Purchases.Count}");

            if (this.Purchases.Count == 0)
            {
                sb.AppendLine("Currently no purchases");
            }
            else
            {
                foreach (var item in this.Purchases)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
