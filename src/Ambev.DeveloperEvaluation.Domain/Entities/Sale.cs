using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Guid BranchId { get; set; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public List<SaleItem> SaleItems { get; set; } = new();
        public SaleStatus Status { get; private set; }
        public decimal TotalAmount => SaleItems.Sum(i => i.TotalItemAmount);

        public Sale(int saleNumber, Guid customerId, Guid branchId, List<SaleItem> items)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            CustomerId = customerId;
            BranchId = branchId;
            Status = SaleStatus.Active;

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void AddItem(SaleItem item)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 units of the same item.");

            item.ApplyDiscount();
            SaleItems.Add(item);
        }

        public void CancelSale()
        {
            Status = SaleStatus.Cancelled;
        }
    }
}