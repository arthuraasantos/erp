using System;

namespace ERP.Services.PurchaseServices.Dtos.Sections
{
    public class SectionNewDto
    {
        public Guid OrganizationId { get; set; }
        public string Description { get; set; }
    }
}
