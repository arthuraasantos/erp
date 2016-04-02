using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class PricePlanDbMapping: OrganizationEntityDbMapping<PricePlan>
    {
        public PricePlanDbMapping()
        {
            Property(p => p.Id).HasColumnName("PricePlanId");
            Property(p => p.Description).HasColumnName("Description");

            ToTable("PricePlans");
        }
    }
}
