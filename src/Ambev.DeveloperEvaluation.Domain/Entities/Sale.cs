namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public int SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Guid CustomerId { get; private set; }  
        public decimal TotalAmount => SaleItems.Sum(i => i.TotalItemAmount);
        public Guid BranchId { get; private set; }  
        public List<SaleItem> SaleItems { get; private set; } = new();
        public bool IsCancelled { get; private set; }

        public Sale(int saleNumber, Guid customerId, Guid branchId, List<SaleItem> items)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            CustomerId = customerId;
            BranchId = branchId;
            IsCancelled = false;

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
            IsCancelled = true;
        }
    }
}