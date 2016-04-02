using System;
using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Products.Stocks
{
    public class StockProduct: AuditableOrganizationEntity
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        
        public Stock Stock { get; set; }
        public Guid StockId { get; set; }

        public double Quantity { get; private set; }

        public void AddItem(double quantity) => Quantity += quantity;
        public void RemoveItem(double quantity) => Quantity -= quantity;
    }
}
