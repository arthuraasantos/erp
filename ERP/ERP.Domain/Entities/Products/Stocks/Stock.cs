using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Products.Stocks
{
    public class Stock: AuditableOrganizationEntity
    {
        public string Description { get; set; }
         
    }
}
