using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.StockProducts;

namespace ERP.Services.PurchaseServices.Converters.Products.StockProducts
{
    public class StockProductDtoConverterOrganizationEntity : IConverterOrganizationEntity<StockProductDto, StockProduct>
    {
        public StockProduct Convert(StockProductDto origin, StockProduct destiny)
        {
            if (destiny == null) destiny = new StockProduct();
            destiny.Id = origin.StockProductId;
            destiny.OrganizationId = origin.OrganizationId;
            destiny.ProductId = origin.ProductId;
            destiny.StockId = origin.StockId;
            destiny.AddItem(origin.Quantity);

            return destiny;
        }

        public StockProductDto Convert(StockProduct origin, StockProductDto destiny)
        {
            if (destiny == null) destiny = new StockProductDto();
            destiny.StockProductId = origin.Id;
            destiny.OrganizationId = origin.OrganizationId;
            destiny.ProductId = origin.ProductId;
            destiny.StockId = origin.StockId;
            destiny.Quantity = origin.Quantity;

            return destiny;
        }
    }
}
