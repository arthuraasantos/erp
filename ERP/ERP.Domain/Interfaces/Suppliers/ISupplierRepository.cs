using System.Collections.Generic;
using ERP.Domain.Entities.Suppliers;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces.Suppliers
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        List<Supplier> GetInactiveSuppliers();
    }
}
