using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Products.Sections;
using ERP.Services.PurchaseServices.Dtos.Sections;

namespace ERP.Services.PurchaseServices.Converters.Products.Sections
{
    public class SectionEditDtoConverterOrganizationEntity : IConverterOrganizationEntity<SectionEditDto,Section>
    {
        public Section Convert(SectionEditDto origin, Section destiny)
        {
            if (destiny == null) destiny = new Section();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.Location = origin.Location;

            return destiny;
        }

        public SectionEditDto Convert(Section origin, SectionEditDto destiny)
        {
            if (destiny == null) destiny = new SectionEditDto();

            destiny.OrganizationId = origin.OrganizationId;
            destiny.Description = origin.Description;
            destiny.Location = origin.Location;

            return destiny;
        }
    }
}
