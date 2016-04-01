using ERP.Domain.Entities.Products.Stocks;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class StockDbMapping: OrganizationEntityDbMapping<Stock>
    {
        public StockDbMapping()
        {
            HasKey(p => p.Id);
            Property(p => p.Description).HasColumnName("Description");

            ToTable("Stocks");
        }
    }
}
