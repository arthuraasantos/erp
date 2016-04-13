using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.StockProducts;

namespace ERP.Services.PurchaseServices.Converters.Products.StockProducts
{
    public class StockProductNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<StockProductNewDto, StockProduct>
    {
        public StockProduct Convert(StockProductNewDto origin, StockProduct destiny)
        {
            if (destiny == null) destiny = new StockProduct();
            destiny.Id = Guid.NewGuid();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.ProductId = origin.ProductId;
            destiny.StockId = origin.StockId;
            destiny.AddItem(origin.Quantity);

            return destiny;
        }

        public StockProductNewDto Convert(StockProduct origin, StockProductNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
