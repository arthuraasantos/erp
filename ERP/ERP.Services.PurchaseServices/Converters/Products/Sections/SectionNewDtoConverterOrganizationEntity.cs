using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Sections;
using ERP.Services.PurchaseServices.Dtos.Sections;

namespace ERP.Services.PurchaseServices.Converters.Products.Sections
{
    public class SectionNewDtoConverterOrganizationEntity : IConverterOrganizationEntity<SectionNewDto, Section>
    {
        public Section Convert(SectionNewDto origin, Section destiny)
        {
            if (destiny == null) destiny = new Section();

            destiny.Id = Guid.NewGuid();
            destiny.Description = origin.Description;
            destiny.OrganizationId = origin.OrganizationId;

            return destiny;
        }

        public SectionNewDto Convert(Section origin, SectionNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
