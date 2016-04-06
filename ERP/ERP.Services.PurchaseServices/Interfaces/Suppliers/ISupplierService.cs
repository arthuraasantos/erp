using System;
using System.Collections.Generic;
using ERP.Services.PurchaseServices.Dtos.Suppliers;

namespace ERP.Services.PurchaseServices.Interfaces.Suppliers
{
    public interface ISupplierService
    {
        Guid Create(SupplierNewDto newSupplier, Guid organizationId);
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetById(Guid id);
        void Delete(Guid id);
        void Update(SupplierEditDto editSupplier);
    }
}
