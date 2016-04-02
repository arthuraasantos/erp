using ERP.Domain.Entities.Products.Stocks;
using ERP.Infrastructure.Data.Mapping.Base;

namespace ERP.Infrastructure.Data.Mapping
{
    internal class StockProductDbMapping: OrganizationEntityDbMapping<StockProduct>
    {
        public StockProductDbMapping()
        {
            Property(p => p.ProductId).IsRequired().HasColumnName("ProductId");
            Property(p => p.StockId).IsRequired().HasColumnName("StockId");

            ToTable("StockProducts");
        }
    }
}
