using System;
using System.Collections.Generic;
using ERP.Services.PurchaseServices.Dtos.Configurations;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Dtos.Purchases
{
    public class PurchaseDto
    {
        public Guid SupplierId { get; set; }
        public Guid StockId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public string Notes { get; set; }
        public decimal DeliveryValue { get; set; }
        public List<PurchaseProductDto> ChildProducts { get; set; }
        public List<ConfigurationDto> Configurations { get; set; }
    }
}
