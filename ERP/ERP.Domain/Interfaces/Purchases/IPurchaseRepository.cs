using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Purchases;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces.Purchases
{
    public interface IPurchaseRepository: IRepositoryBase<Purchase>
    {
        IEnumerable<Purchase> ActualMonth(Guid organizationId);

    }
}
