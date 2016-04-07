using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Purchases;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts
{
    public class PurchaseProductNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<PurchaseProductNewDto, PurchaseProduct>
    {
        public PurchaseProduct Convert(PurchaseProductNewDto origin, PurchaseProduct destiny)
        {
            if (destiny == null) destiny = new PurchaseProduct();

            destiny.PurcharseId = origin.PurcharseId;
            destiny.Id = origin.PurchaseProductId;
            destiny.Quantity = origin.Quantity;
            destiny.Value = origin.Value;

            return destiny;
        }

        public PurchaseProductNewDto Convert(PurchaseProduct origin, PurchaseProductNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
