using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Sections;
using ERP.Services.PurchaseServices.Dtos.Sections;

namespace ERP.Services.PurchaseServices.Converters.Products.Sections
{
    public class SectionDtoConverterOrganizationEntity : IConverterOrganizationEntity<SectionDto, Section>
    {
        public Section Convert(SectionDto origin, Section destiny)
        {
            if (destiny == null) destiny = new Section();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.Location = origin.Location;

            return destiny;
        }

        public SectionDto Convert(Section origin, SectionDto destiny)
        {
            if (destiny == null) destiny = new SectionDto();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.Location = origin.Location;

            return destiny;
        }
    }
}
