using ERP.Domain.Entities.Products.Stocks;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class StockDbMapping: OrganizationEntityDbMapping<Stock>
    {
        public StockDbMapping()
        {
            Property(p => p.Id).HasColumnName("StockId");
            Property(p => p.Description).HasColumnName("Description");

            ToTable("Stocks");
        }
    }
}
