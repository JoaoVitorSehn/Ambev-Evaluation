using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid ProductId { get; private set; }  
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalItemAmount => (UnitPrice * Quantity) - Discount;

        protected SaleItem() { } 

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = 0;
        }

        public void ApplyDiscount()
        {
            if (Quantity >= 4 && Quantity < 10)
                Discount = (UnitPrice * Quantity) * 0.10m;
            else if (Quantity >= 10 && Quantity <= 20)
                Discount = (UnitPrice * Quantity) * 0.20m;
            else
                Discount = 0;
        }
    }
}