using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Domain.Entities.Products.Sections;
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
        public Guid? SectionId { get; set; }

        public PricePlan PricePlan { get; set; } 
        public Guid? PricePlanId { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public bool IsActive() => ProductService.IsActive(this);
        public double InStock() => ProductService.InStock(this);
    }
}
