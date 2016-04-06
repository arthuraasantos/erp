using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Organizations;
using ERP.Services.PurchaseServices.Converters.Address;
using ERP.Services.PurchaseServices.Dtos.Organizations;

namespace ERP.Services.PurchaseServices.Converters.Organizations
{
    public class ConverterOrganizationEditDtoToDomain : ConverterOrganizationEntity<OrganizationEditDto,Organization>
    {
        public override Organization Convert(OrganizationEditDto origin, Organization destiny)
        {
            destiny.Id = origin.OrganizationId;
            destiny.Name = origin.Name;
            destiny.Email = origin.Email;
            destiny.RegistrationName = origin.RegistrationName;
            destiny.RegistrationCode = origin.RegistrationCode;
            destiny.Address = ConverterAddressDtoToDomain.Convert(origin.Address,null);
            

            return destiny;
        }

        public override OrganizationEditDto Convert(Organization origin, OrganizationEditDto destiny)
        {
            throw new ArgumentException("Método proibido de ser utilizado");
        }
    }
}
