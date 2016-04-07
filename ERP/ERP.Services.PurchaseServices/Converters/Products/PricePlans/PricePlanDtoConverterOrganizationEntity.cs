using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Services.PurchaseServices.Dtos.PricePlans;

namespace ERP.Services.PurchaseServices.Converters.Products.PricePlans
{
    public class PricePlanDtoConverterOrganizationEntity : IConverterOrganizationEntity<PricePlanDto, PricePlan>
    {
        public PricePlan Convert(PricePlanDto origin, PricePlan destiny)
        {
            if (destiny == null) destiny = new PricePlan();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Id = origin.PricePlanId;
            destiny.Description = origin.Description;
            destiny.AliquotValue = origin.AliquotValue;

            return destiny;
        }

        public PricePlanDto Convert(PricePlan origin, PricePlanDto destiny)
        {
            if (destiny == null) destiny = new PricePlanDto();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.PricePlanId = origin.Id;
            destiny.Description = origin.Description;
            destiny.AliquotValue = origin.AliquotValue;

            return destiny;
        }
    }
}
