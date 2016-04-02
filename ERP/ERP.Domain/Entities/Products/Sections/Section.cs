using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Products.Sections
{
    public class Section: AuditableOrganizationEntity
    {
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
