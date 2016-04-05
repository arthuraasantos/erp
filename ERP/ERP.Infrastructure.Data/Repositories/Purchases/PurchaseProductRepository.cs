using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Domain.Common;
using ERP.Domain.Entities.Purchases;
using ERP.Domain.Interfaces.Purchases;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Purchases
{
    public class PurchaseProductRepository: RepositoryBase<PurchaseProduct>, IPurchaseProductRepository
    {
        public PurchaseProductRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<PurchaseProduct> OnlyThisPurchaseProducts(Guid organizationId, Guid purchaseId)
        {
            return Uow.PurchaseProducts.Where(p => p.PurcharseId == purchaseId);
        }
    }
}
