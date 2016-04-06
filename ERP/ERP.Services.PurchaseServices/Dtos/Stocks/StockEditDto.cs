﻿using System;

namespace ERP.Services.PurchaseServices.Dtos.Stocks
{
    public class StockEditDto
    {
        public Guid StockId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Description { get; set; }
    }
}
