using System;
using ERP.Domain.Interfaces.Products.PricePlans;
using ERP.Services.PurchaseServices.Converters.Products.PricePlans;
using ERP.Services.PurchaseServices.Dtos.PricePlans;
using ERP.Services.PurchaseServices.Interfaces.Products.PricePlans;

namespace ERP.Services.PurchaseServices.Services.Products.PricePlans
{
    public class PricePlanService : IPricePlanService
    {
        private readonly IPricePlanRepository _pricePlanRepository;
        private readonly PricePlanNewDtoConverterOrganizationEntity _converterPricePlanNewDto;
        private readonly PricePlanEditDtoConverterOrganizationEntity _converterPricePlanEditDto;
        private readonly PricePlanDtoConverterOrganizationEntity _converterPricePlantDto;

        public PricePlanService(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepository = pricePlanRepository;
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

                _pricePlanRepository.Save(pricePlan);
                _pricePlanRepository.Execute();

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

        public PricePlanDto Get(Guid id)
        {
            try
            {
                var priceplan = _pricePlanRepository.Get(id);
                var pricePlanDto = _converterPricePlantDto.Convert(priceplan, null);

                return pricePlanDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter plano de preço: {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var pricePlan = _pricePlanRepository.Get(id);
                _pricePlanRepository.Delete(pricePlan);
                _pricePlanRepository.Execute();
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
            _pricePlanRepository.Save(pricePlan);
        }

        private static bool IsValidEditPricePlan(PricePlanEditDto editPricePlan)
        {
            return !string.IsNullOrWhiteSpace(editPricePlan.Description);
        }
    }
}
