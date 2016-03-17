using System;
using ERP.Domain.Interfaces.Suppliers;
using ERP.Services.PurchaseServices.Converters.Suppliers;
using ERP.Services.PurchaseServices.Dtos.Supplier;
using ERP.Services.PurchaseServices.Interfaces;

namespace ERP.Services.PurchaseServices.Services.Suppliers
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierNewDtoConverter _supplierConverter;

        public SupplierAppService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
            _supplierConverter = new SupplierNewDtoConverter();
        }

        public Guid CreateSupplier(SupplierNewDto newSupplier)
        {
            try
            {
                if (!IsValidNewSupplier(newSupplier)) throw  new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var supplier = _supplierConverter.Convert(newSupplier, null);
                _supplierRepository.Save(supplier);
                _supplierRepository.Execute();

                return supplier.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar fornecedor:  {ex.Message}");     
            }
        }

        private static bool IsValidNewSupplier(SupplierNewDto supplierNewDto)
        {
            return 
                !string.IsNullOrWhiteSpace(supplierNewDto.CpfCnpj.ToString()) && 
                !string.IsNullOrWhiteSpace(supplierNewDto.Name) &&
                !string.IsNullOrWhiteSpace(supplierNewDto.Email);
        }
    }
}
