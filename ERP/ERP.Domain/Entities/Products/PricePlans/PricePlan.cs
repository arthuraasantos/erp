using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Products.PricePlans
{
    public class PricePlan: AuditableOrganizationEntity
    {
        public string Description { get; set; }
        public decimal Value { get; set; } 
    }
}
