using System;
using System.Linq;
using ERP.Domain.Interfaces.Products.PricePlans;
using ERP.Services.PurchaseServices.Converters.Products.PricePlans;
using ERP.Services.PurchaseServices.Dtos.PricePlans;
using ERP.Services.PurchaseServices.Interfaces.Products.PricePlans;

namespace ERP.Services.PurchaseServices.Services.Products.PricePlans
{
    public class PricePlanService : IPricePlanService
    {
        private readonly IPricePlanRepository _pricePlanRepositoryOrganization;
        private readonly PricePlanNewDtoConverterOrganizationEntity _converterPricePlanNewDto;
        private readonly PricePlanEditDtoConverterOrganizationEntity _converterPricePlanEditDto;
        private readonly PricePlanDtoConverterOrganizationEntity _converterPricePlantDto;

        public PricePlanService(IPricePlanRepository pricePlanRepositoryOrganization)
        {
            _pricePlanRepositoryOrganization = pricePlanRepositoryOrganization;
            _converterPricePlanNewDto = new PricePlanNewDtoConverterOrganizationEntity();
            _converterPricePlanEditDto = new PricePlanEditDtoConverterOrganizationEntity();
            _converterPricePlantDto = new PricePlanDtoConverterOrganizationEntity();
        }

        public Guid Create(PricePlanNewDto newPricePlan, Guid organizationId)
        {
            try
            {
                if (!IsValidNewPricePlan(newPricePlan)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newPricePlan.OrganizationId = organizationId;
                var pricePlan = _converterPricePlanNewDto.Convert(newPricePlan, null);

                _pricePlanRepositoryOrganization.Save(pricePlan);
                _pricePlanRepositoryOrganization.Execute();

                return pricePlan.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar plano de preço:  {ex.Message} ");
            }
        }

        private static bool IsValidNewPricePlan(PricePlanNewDto newPricePlan)
        {
            return !string.IsNullOrWhiteSpace(newPricePlan.Description);
        }

        public PricePlanDto Get(Guid id, Guid organizationId)
        {
            try
            {
                var priceplan = _pricePlanRepositoryOrganization.Get(id, organizationId);
                var pricePlanDto = _converterPricePlantDto.Convert(priceplan, null);

                return pricePlanDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter plano de preço: {ex.Message}");
            }
        }

        public void Delete(Guid id, Guid organizationId)
        {
            try
            {
                var pricePlan = _pricePlanRepositoryOrganization.Get(id, organizationId);
                _pricePlanRepositoryOrganization.Delete(pricePlan);
                _pricePlanRepositoryOrganization.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar plano de preço: {ex.Message}");
            }
        }

        public void Update(PricePlanEditDto editPricePlan)
        {
            if (IsValidEditPricePlan(editPricePlan)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

            var pricePlan = _converterPricePlanEditDto.Convert(editPricePlan, null);
            _pricePlanRepositoryOrganization.Save(pricePlan);
        }

        private static bool IsValidEditPricePlan(PricePlanEditDto editPricePlan)
        {
            return !string.IsNullOrWhiteSpace(editPricePlan.Description);
        }
    }
}
