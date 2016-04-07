using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Interfaces.Purchases;
using ERP.Services.PurchaseServices.Converters.Purchases.PurchaseProducts;
using ERP.Services.PurchaseServices.Dtos.PurchaseProducts;
using ERP.Services.PurchaseServices.Interfaces.Purchases;

namespace ERP.Services.PurchaseServices.Services.Purchases
{
    public class PurchaseProductService : IPurchaseProductService
    {
        private readonly IPurchaseProductRepository _purchaseProductRepository;
        private readonly PurchaseProductNewDtoConverterOrganizationEntity _converterPurchaseProductNewDto;
        private readonly PurchaseProductEditDtoConverterOrganizationEntity _converterPurchaseProductEditDto;
        private readonly PurchaseProductDtoConverterOrganizationEntity _converterPurchaseProductDto;

        public PurchaseProductService(IPurchaseProductRepository purchaseProductRepository)
        {
            _purchaseProductRepository = purchaseProductRepository;
            _converterPurchaseProductDto = new PurchaseProductDtoConverterOrganizationEntity();
            _converterPurchaseProductNewDto = new PurchaseProductNewDtoConverterOrganizationEntity();
            _converterPurchaseProductEditDto = new PurchaseProductEditDtoConverterOrganizationEntity();
        }

        public Guid Create(PurchaseProductNewDto newPurchaseProduct, Guid organizationId)
        {
            try
            {
                if (!IsValidNewPurchaseProduct(newPurchaseProduct))
                    throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newPurchaseProduct.OrganizationId = organizationId;
                var purchaseProduct = _converterPurchaseProductNewDto.Convert(newPurchaseProduct, null);

                _purchaseProductRepository.Save(purchaseProduct);
                _purchaseProductRepository.Execute();

                return purchaseProduct.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar novo produto dentro da compra:  {ex.Message} ");
            }
        }

       

        public PurchaseProductDto Get(Guid id)
        {
            try
            {
                var purchaseProduct = _purchaseProductRepository.Get(id);
                var purchaseProductDto = _converterPurchaseProductDto.Convert(purchaseProduct, null);

                return purchaseProductDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter produto de uma compra: {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var purchaseProduct = _purchaseProductRepository.Get(id);
                _purchaseProductRepository.Delete(purchaseProduct);
                _purchaseProductRepository.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar produto de uma compra: {ex.Message}");
            }
        }

        public void Update(PurchaseProductEditDto editPurchaseProduct)
        {
            try
            {
                if (IsValidEditPurchaseProduct(editPurchaseProduct)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var purchaseProduct = _converterPurchaseProductEditDto.Convert(editPurchaseProduct, null);
                _purchaseProductRepository.Save(purchaseProduct);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar produto de uma compra: {ex.Message}");
            }
        }

        private static bool IsValidNewPurchaseProduct(PurchaseProductNewDto newPurchaseProduct)
          => newPurchaseProduct.Quantity > 0 && newPurchaseProduct.Value > 0;


        private static bool IsValidEditPurchaseProduct(PurchaseProductEditDto editPurchaseProduct)
          => editPurchaseProduct.Quantity > 0 && editPurchaseProduct.Value > 0;
    }
}
