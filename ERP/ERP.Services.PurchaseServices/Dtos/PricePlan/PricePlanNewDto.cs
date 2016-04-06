using System;

namespace ERP.Services.PurchaseServices.Dtos.PricePlan
{
    public class PricePlanNewDto
    {
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
        public decimal AliquotValue { get; set; }
    }
}
