using System;
using System.Collections.Generic;
using ERP.Domain.Common;
using ERP.Domain.Entities.Suppliers;
using ERP.Domain.Interfaces.Suppliers;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Suppliers
{
    public class SupplierRepository: RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
        }

        public List<Supplier> GetInactiveSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
