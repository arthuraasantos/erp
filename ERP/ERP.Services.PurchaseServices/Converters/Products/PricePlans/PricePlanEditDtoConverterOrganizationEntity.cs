using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Services.PurchaseServices.Dtos.PricePlans;

namespace ERP.Services.PurchaseServices.Converters.Products.PricePlans
{
    public class PricePlanEditDtoConverterOrganizationEntity : IConverterOrganizationEntity<PricePlanEditDto, PricePlan>
    {
        public PricePlan Convert(PricePlanEditDto origin, PricePlan destiny)
        {
            if (destiny == null) destiny = new PricePlan();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Id = origin.PricePlanId;
            destiny.Description = origin.Description;
            destiny.AliquotValue = origin.AliquotValue;

            return destiny;
        }

        public PricePlanEditDto Convert(PricePlan origin, PricePlanEditDto destiny)
        {
            if (destiny == null) destiny = new PricePlanEditDto();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.PricePlanId = origin.Id;
            destiny.Description = origin.Description;
            destiny.AliquotValue = origin.AliquotValue;

            return destiny;
        }
    }
}
