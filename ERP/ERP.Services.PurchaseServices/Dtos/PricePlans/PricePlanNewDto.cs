using System;

namespace ERP.Services.PurchaseServices.Dtos.PricePlans
{
    public class PricePlanNewDto
    {
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
        public decimal AliquotValue { get; set; }
    }
}
