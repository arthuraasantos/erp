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
             Tem que aparecer o nome do Id na tabela direitinho !! 
            ToTable("PricePlans");
        }
    }
}
