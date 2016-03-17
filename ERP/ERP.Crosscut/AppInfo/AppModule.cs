using System;


namespace ERP.Crosscut.AppInfo
{
    public static class AppModule
    {
        private static readonly Guid _purchaseId = Guid.Parse("f8e2f349-d3c1-4b46-b2ca-e8ee233cd078");
        private static readonly Guid _salesId = Guid.Parse("dc32ab42-d24e-4e87-934e-bd8811dd3259");
        private static readonly Guid _stockId = Guid.Parse("9d2e4a36-9844-4ca6-b4ad-91fff4be75c1");
        private static readonly Guid _financiaslId = Guid.Parse("3ac71a28-1b83-4e36-83aa-98d627861afd");

        public static Guid GetPurchaseClientId() => _purchaseId;
        public static Guid GetSalesClientId() => _salesId;
        public static Guid GetStockClientId() => _stockId;
        public static Guid GetFinancialsClientId() => _financiaslId;

    }
}
