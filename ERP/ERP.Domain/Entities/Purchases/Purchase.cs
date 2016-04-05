using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Configurations;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Domain.Entities.Suppliers;
using ERP.Domain.Services.Purchases;

namespace ERP.Domain.Entities.Purchases
{
    public class Purchase: AuditableOrganizationEntity
    {
        public DateTime InvoiceDate { get; set; }
        public string Notes { get; set; }
        public decimal DeliveryValue { get; set; }
        public List<PurchaseProduct> ChildProducts { get; set; }
        public List<Configuration> Configurations { get; set; }
        

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public Guid StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public decimal CalculateTotal(List<PurchaseProduct> products, decimal deliveryValue)
            => PurchaseService.CalculateTotal(products, deliveryValue);

        public bool IsValid() => PurchaseService.IsValid(this);

    }
}
