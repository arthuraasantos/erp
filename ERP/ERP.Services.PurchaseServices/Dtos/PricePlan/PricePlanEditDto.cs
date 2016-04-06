using System;

namespace ERP.Services.PurchaseServices.Dtos.PricePlan
{
    public class PricePlanEditDto
    {
        public Guid PricePlanId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
        public decimal AliquotValue { get; set; }
    }
}
