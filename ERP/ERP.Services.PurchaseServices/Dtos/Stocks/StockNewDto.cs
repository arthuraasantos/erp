using System;

namespace ERP.Services.PurchaseServices.Dtos.Stocks
{
    public class StockNewDto
    {
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
    }
}
