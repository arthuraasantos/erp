using System;
using System.Collections.Generic;
using ERP.Crosscut.UnitOfWork;
using ERP.Domain.Common;
using ERP.Domain.Entities.Suppliers;
using ERP.Infrastructure.Data.Context.Shopping;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Suppliers
{
    public class SupplierRepository: RepositoryBase<Supplier>
    {
        public SupplierRepository(IUnitOfWork uow, PurchaseUnitOfWork context) : base(uow, context)
        {
        }
       
    }
}
