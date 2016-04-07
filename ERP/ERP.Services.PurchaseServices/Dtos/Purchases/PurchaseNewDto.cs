using System;
using System.Collections.Generic;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Dtos.Purchases
{
    public class PurchaseNewDto
    {
        public Guid OrganizationId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid StockId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string Notes { get; set; }
        public decimal DeliveryValue { get; set; }
        public List<PurchaseProductDto> ChildProducts { get; set; }
    }
}
