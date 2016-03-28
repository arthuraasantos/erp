using System.Collections.Generic;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Organizations;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Domain.Entities.Products.Sections;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Domain.Entities.Suppliers;
using ERP.Domain.Services.Products;

namespace ERP.Domain.Entities.Products
{
    public class Product : AuditableOrganizationEntity
    {
        public string Description { get; set; }
        public List<string> UniversalCodes { get; set; }
        public string EanCode { get; set; }

        public Section Section { get; set; }
        public PricePlan PricePlan { get; set; } 
        public Supplier Supplier { get; set; }

        public virtual StockProduct StockProduct { get; set; }
        public virtual Organization Organization { get; set; }

        public bool IsActive() => ProductService.IsActive(this);
        public double InStock() => ProductService.InStock(this);
    }
}
