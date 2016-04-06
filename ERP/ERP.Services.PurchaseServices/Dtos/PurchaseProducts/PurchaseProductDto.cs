using System;

namespace ERP.Services.PurchaseServices.Dtos.PurchaseProducts
{
    public class PurchaseProductDto
    {
        public Guid OrganizationId { get; set; }
        public Guid PurchaseProductId { get; set; }
        public Guid PurcharseId { get; set; }

        public double Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
