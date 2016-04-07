using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.PricePlans;
using ERP.Services.PurchaseServices.Dtos.PricePlans;

namespace ERP.Services.PurchaseServices.Converters.Products.PricePlans
{
    public class PricePlanNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<PricePlanNewDto, PricePlan>
    {
        public PricePlan Convert(PricePlanNewDto origin, PricePlan destiny)
        {
            if (destiny == null) destiny = new PricePlan();
            destiny.Id = Guid.NewGuid();
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.AliquotValue = origin.AliquotValue;

            return destiny;
        }

        public PricePlanNewDto Convert(PricePlan origin, PricePlanNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
