using System;

namespace ERP.Services.PurchaseServices.Dtos.Products
{
    public class ProductNewDto
    {
        public Guid OrganizationId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid? PricePlanId { get; set; }

        public string Description { get; set; }
        public string EanCode { get; set; }
    }
}
