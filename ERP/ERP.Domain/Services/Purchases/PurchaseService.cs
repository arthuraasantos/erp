using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Purchases;

namespace ERP.Domain.Services.Purchases
{
    public static class PurchaseService
    {
        public static decimal CalculateTotal(List<PurchaseProduct> products, decimal deliveryValue)
            => products.Sum(p => p.Value) + deliveryValue;

        public static bool IsValid(Purchase purchase)
            => purchase.ChildProducts != null && purchase.Stock != null && purchase.Supplier != null;
    }
}
