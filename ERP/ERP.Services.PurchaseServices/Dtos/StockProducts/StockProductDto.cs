﻿using System;

namespace ERP.Services.PurchaseServices.Dtos.StockProducts
{
    public class StockProductDto
    {
        public Guid StockProductId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid StockId { get; set; }

        public double Quantity { get; set; }
    }
}
