using System;
using System.Linq;
using ERP.Domain.Entities.Common;
using ERP.Domain.Entities.Organizations;
using static ERP.Infrastructure.Data.EntitiesSeed.SeedInitialize;

namespace ERP.Infrastructure.Data.PurchaseMigrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ERP.Infrastructure.Data.Context.Purchase.PurchaseUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"PurchaseMigrations";
        }

        protected override void Seed(Context.Purchase.PurchaseUnitOfWork context)
        {
            #region Organizations

            var organization = InitializeOrganization();

            if (!context.Organizations.Any(x => x.Id == organization.Id))
                context.Organizations.Add(organization);

            #endregion
            context.Commit();

            #region Sections

            var section = InitializeSection(organization.Id);
            if (!context.Sections.Any(x => x.Id == section.Id))
                context.Sections.Add(section);

            #endregion
            context.Commit();

            #region Stocks

            var stock = InitiliazeStock(organization.Id);
            if (!context.Stocks.Any(x => x.Id == stock.Id))
                context.Stocks.Add(stock);

            #endregion
            context.Commit();

            #region PricePlans

            var pricePlan = InitializePricePlan(organization.Id);
            if (!context.PricePlans.Any(x => x.Id == pricePlan.Id))
                context.PricePlans.Add(pricePlan);

            #endregion
            context.Commit();

            #region Products

            var product = InitializeProduct(organization.Id, section,pricePlan);
            if (!context.Products.Any(x => x.Id == product.Id))
                context.Products.Add(product);

            #endregion
            context.Commit();

            #region StockProducts

            var stockProduct = InitializeStockProduct(organization.Id, product.Id, stock.Id);
            if (!context.StockProducts.Any(x => x.Id == stockProduct.Id))
                context.StockProducts.Add(stockProduct);

            #endregion
            context.Commit();

            #region Suppliers

            var supplier = InitializeSupplier(organization.Id);
            if (!context.Suppliers.Any(x => x.Id == supplier.Id))
                context.Suppliers.Add(supplier);

            #endregion 
            context.Commit();
        }
    }
}
