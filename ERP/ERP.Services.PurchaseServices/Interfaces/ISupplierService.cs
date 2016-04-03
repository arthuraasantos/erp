using System;
using ERP.Services.PurchaseServices.Dtos.Supplier;
using System.Collections.Generic;

namespace ERP.Services.PurchaseServices.Interfaces
{
    public interface ISupplierService
    {
        Guid CreateSupplier(SupplierNewDto newSupplier, Guid organizationId);
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetById(Guid id);
        void Delete(Guid id);
        void Update(SupplierEditDto supplierEditDto);
    }
}
