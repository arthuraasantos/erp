using System;
using System.Collections.Generic;
using ERP.Services.PurchaseServices.Dtos.Suppliers;

namespace ERP.Services.PurchaseServices.Dtos.Products
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid? PricePlanId { get; set; }

        public string Description { get; set; }
        public string EanCode { get; set; }
        public List<SupplierDto> Suppliers { get; set; }
        public List<string> UniversalCodes { get; set; }
    }
}
