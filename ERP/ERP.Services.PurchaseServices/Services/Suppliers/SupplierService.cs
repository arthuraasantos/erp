using System;
using System.Collections.Generic;
using ERP.Domain.Interfaces.Suppliers;
using ERP.Services.PurchaseServices.Converters.Suppliers;
using ERP.Services.PurchaseServices.Dtos.Suppliers;
using ERP.Services.PurchaseServices.Interfaces;
using ERP.Services.PurchaseServices.Interfaces.Suppliers;

namespace ERP.Services.PurchaseServices.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierNewDtoConverterOrganizationEntity _supplierNewDtoConverterOrganizationEntity;
        private readonly SupplierDtoConverterOrganizationEntity _supplierDtoConverterOrganizationEntity;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
            _supplierNewDtoConverterOrganizationEntity = new SupplierNewDtoConverterOrganizationEntity();
            _supplierDtoConverterOrganizationEntity = new SupplierDtoConverterOrganizationEntity();
        }

        public Guid Create(SupplierNewDto newSupplier, Guid organizationId)
        {
            try
            {
                if (!IsValidNewSupplier(newSupplier)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var supplier = _supplierNewDtoConverterOrganizationEntity.Convert(newSupplier, null);
                supplier.OrganizationId = organizationId;
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

        public IEnumerable<SupplierDto> GetAll()
        {
            try
            {
                var suppliers = _supplierRepository.GetAll();
                var listSupplierDto = new List<SupplierDto>();

                foreach (var item in suppliers)
                {
                    var supplierDto = _supplierDtoConverterOrganizationEntity.Convert(item, null);
                    listSupplierDto.Add(supplierDto);
                }

                return listSupplierDto;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter os fornecedores: {ex.Message}");
            }
        }

        public SupplierDto GetById(Guid id)
        {
            try
            {
                var supplier = _supplierRepository.Get(id);
                var supplierDto = _supplierDtoConverterOrganizationEntity.Convert(supplier, null);

                return supplierDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter fornecedor: {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var supplierDto = GetById(id);
                var supplier = _supplierDtoConverterOrganizationEntity.Convert(supplierDto, null);
                _supplierRepository.Delete(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o fornecedor: {ex.Message}");
            }
        }

        public void Update(SupplierEditDto supplierEditDto)
        {
            //TODO
            throw new NotImplementedException("Não utilizar este método!");
        }
    }
}
