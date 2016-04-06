using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services.PurchaseServices.Dtos.Sections
{
    public class SectionEditDto
    {
        public Guid SectionId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }
    }
}
