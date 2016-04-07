using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Purchases;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;

namespace ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts
{
    public class PurchaseProductEditDtoConverterOrganizationEntity : IConverterOrganizationEntity<PurchaseProductEditDto, PurchaseProduct>
    {
        public PurchaseProduct Convert(PurchaseProductEditDto origin, PurchaseProduct destiny)
        {
            if (destiny == null) destiny = new PurchaseProduct();

            destiny.PurcharseId = origin.PurcharseId;
            destiny.Id = origin.PurchaseProductId;
            destiny.Quantity = origin.Quantity;
            destiny.Value = origin.Value;

            return destiny;
        }

        public PurchaseProductEditDto Convert(PurchaseProduct origin, PurchaseProductEditDto destiny)
        {
            if (destiny == null) destiny = new PurchaseProductEditDto();

            destiny.PurcharseId = origin.PurcharseId;
            destiny.PurchaseProductId = origin.Id;
            destiny.Quantity = origin.Quantity;
            destiny.Value = origin.Value;

            return destiny;
        }
    }
}
