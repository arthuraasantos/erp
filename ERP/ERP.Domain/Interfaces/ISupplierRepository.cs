using System;
using System.Collections.Generic;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces
{
    public interface ISupplierRepository : IRepositoryBase<Supplier,Guid>
    {
        List<Supplier> GetInactiveSuppliers();
    }
}
