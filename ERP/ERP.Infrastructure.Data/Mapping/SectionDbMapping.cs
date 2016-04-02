using ERP.Domain.Entities.Products.Sections;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class SectionDbMapping: OrganizationEntityDbMapping<Section>
    {
        public SectionDbMapping()
        {
            Property(p => p.Id).HasColumnName("SectionId");
            Property(p => p.Description).HasColumnName("Description");
            Property(p => p.Location).HasColumnName("Location");

            ToTable("Sections");
        }
    }
}
