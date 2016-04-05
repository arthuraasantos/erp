using System;
using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Purchases
{
    public class PurchaseProduct : AuditableBase
    {
        public double Quantity { get; set; }
        public decimal Value { get; set; }

        public Guid PurcharseId { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
