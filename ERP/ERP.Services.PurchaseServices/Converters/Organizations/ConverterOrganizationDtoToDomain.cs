using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Organizations;
using ERP.Services.PurchaseServices.Dtos.Organization;

namespace ERP.Services.PurchaseServices.Converters.Organizations
{
    public class ConverterOrganizationDtoToDomain : ConverterOrganizationEntity<OrganizationNewDto,Organization>
    {
        public override Organization Convert(OrganizationNewDto origin, Organization destiny)
        {
            if (destiny == null) destiny = new Organization() { Id = Guid.NewGuid() };
            destiny.Name = origin.Name;

            return destiny;
        }

        public override OrganizationNewDto Convert(Organization origin, OrganizationNewDto destiny)
        {
            throw new ArgumentException("Método proibido de ser utilizado");
        }
    }
}
