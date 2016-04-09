using System;
using ERP.Domain.Interfaces.Purchases;
using ERP.Services.PurchaseServices.Converters.Purchases;
using ERP.Services.PurchaseServices.Dtos.Purchases;
using ERP.Services.PurchaseServices.Interfaces.Purchases;

namespace ERP.Services.PurchaseServices.Services.Purchases
{
    public class PurchaseService: IPurchaseServiceOrganization
    {
        private readonly IPurchaseRepository _purchaseRepositoryOrganization;
        private readonly PurchaseNewDtoConverterOrganizationEntity _converterNewDto;
        private readonly PurchaseEditDtoConverterOrganizationEntity _converterEditDto;
        private readonly PurchaseDtoConverterOrganizationEntity _converterDto;

        public PurchaseService(IPurchaseRepository purchaseRepositoryOrganization)
        {
            _purchaseRepositoryOrganization = purchaseRepositoryOrganization;
            _converterEditDto = new PurchaseEditDtoConverterOrganizationEntity();
            _converterDto = new PurchaseDtoConverterOrganizationEntity();
            _converterNewDto = new PurchaseNewDtoConverterOrganizationEntity();
        }


        public Guid Create(PurchaseNewDto newPurchase, Guid organizationId)
        {
            try
            {
                if (!IsValidNewPurchase(newPurchase))
                    throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newPurchase.OrganizationId = organizationId;
                var purchase = _converterNewDto.Convert(newPurchase, null);

                _purchaseRepositoryOrganization.Save(purchase);
                _purchaseRepositoryOrganization.Execute();

                return purchase.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar nova compra:  {ex.Message} ");
            }
        }

        public PurchaseDto Get(Guid id, Guid organizationId)
        {
            try
            {
                var purchase = _purchaseRepositoryOrganization.Get(id, organizationId);
                var purchaseDto = _converterDto.Convert(purchase, null);

                return purchaseDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter compra: {ex.Message}");
            }
        }

        public void Delete(Guid id, Guid organizationId)
        {
            try
            {
                var purchase = _purchaseRepositoryOrganization.Get(id, organizationId);
                _purchaseRepositoryOrganization.Delete(purchase);
                _purchaseRepositoryOrganization.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar compra: {ex.Message}");
            }
        }

        public void Update(PurchaseEditDto editPurchase)
        {
            try
            {
                if (IsValidEditPurchase(editPurchase)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var purchase = _converterEditDto.Convert(editPurchase, null);
                _purchaseRepositoryOrganization.Save(purchase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar compra: {ex.Message}");
            }
        }

        private static bool IsValidNewPurchase(PurchaseNewDto newPurchase)
           => newPurchase.ChildProducts.Count > 0;

        private static bool IsValidEditPurchase(PurchaseEditDto editPurchase)
           => editPurchase.ChildProducts.Count > 0;

        
    }
}
