using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Purchases;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces.Purchases
{
    public interface IPurchaseProductRepository: IRepositoryBase<PurchaseProduct>
    {
        IEnumerable<PurchaseProduct> OnlyThisPurchaseProducts(Guid organizationId, Guid purchaseId);
    }
}
