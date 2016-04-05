using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Domain.Common;
using ERP.Domain.Entities.Purchases;
using ERP.Domain.Interfaces.Purchases;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Purchases
{
    public class PurchaseRepository: RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<Purchase> ActualMonth(Guid organizationId) 
            => Uow.Purchases.Where(p => p.OrganizationId == organizationId && p.CreateDate.Month == DateTime.Now.Month);
    }
}
