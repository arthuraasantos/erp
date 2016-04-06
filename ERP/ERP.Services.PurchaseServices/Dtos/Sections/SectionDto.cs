using System;

namespace ERP.Services.PurchaseServices.Dtos.Sections
{
    public class SectionDto
    {
        public Guid SectionId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }
    }
}
