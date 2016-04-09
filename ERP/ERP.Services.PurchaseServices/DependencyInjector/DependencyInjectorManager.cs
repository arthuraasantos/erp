using ERP.Domain.Common;
using ERP.Domain.Interfaces.Organizations;
using ERP.Domain.Interfaces.Products;
using ERP.Domain.Interfaces.Products.PricePlans;
using ERP.Domain.Interfaces.Products.Sections;
using ERP.Domain.Interfaces.Products.Stocks;
using ERP.Domain.Interfaces.Purchases;
using ERP.Domain.Interfaces.Suppliers;
using ERP.Infrastructure.Data.Context.Purchase;
using ERP.Infrastructure.Data.Repositories.Organizations;
using ERP.Infrastructure.Data.Repositories.Products;
using ERP.Infrastructure.Data.Repositories.Products.PricePlans;
using ERP.Infrastructure.Data.Repositories.Products.Sections;
using ERP.Infrastructure.Data.Repositories.Products.Stocks;
using ERP.Infrastructure.Data.Repositories.Purchases;
using ERP.Infrastructure.Data.Repositories.Suppliers;
using ERP.Services.PurchaseServices.Interfaces.Organizations;
using ERP.Services.PurchaseServices.Interfaces.Products;
using ERP.Services.PurchaseServices.Interfaces.Products.PricePlans;
using ERP.Services.PurchaseServices.Interfaces.Products.Sections;
using ERP.Services.PurchaseServices.Interfaces.Products.Stocks;
using ERP.Services.PurchaseServices.Interfaces.Purchases;
using ERP.Services.PurchaseServices.Interfaces.Suppliers;
using ERP.Services.PurchaseServices.Services.Organizations;
using ERP.Services.PurchaseServices.Services.Products;
using ERP.Services.PurchaseServices.Services.Products.PricePlans;
using ERP.Services.PurchaseServices.Services.Products.Sections;
using ERP.Services.PurchaseServices.Services.Products.Stocks;
using ERP.Services.PurchaseServices.Services.Purchases;
using ERP.Services.PurchaseServices.Services.Suppliers;
using SimpleInjector;

namespace ERP.Services.PurchaseServices.DependencyInjector
{
    public static class DependencyInjectorManager
    {
        public static Container RegisterDependencies(Container container)
        {
            
            //RegisterContexts(container);
            RegisterUnitOfWork(container);
            RegisterInfrastructure(container);
            RegisterServices(container);

            return container;
        }

        //private static void RegisterContexts(Container container)
        //{
        //    //container.Register<IErpContext, ErpContext>();
        //    //container.Register<IUser,User>();
        //    //container.Register<IClient,Client>();
        //    //container.Register<IOrganization,Organization>();
        //}

        private static void RegisterUnitOfWork(Container container)
        {
            container.Register<IPurchaseUnitOfWork, PurchaseUnitOfWork>();
        }

        private static void RegisterInfrastructure(Container container)
        {
            container.Register<ISupplierRepository,SupplierRepository>();
            container.Register<IPurchaseRepository,PurchaseRepository>();
            container.Register<IPurchaseProductRepository,PurchaseProductRepository>();
            container.Register<ISectionRepository,SectionRepository>();
            container.Register<IStockRepository,StockRepository>();
            container.Register<IStockProductRepository,StockProductRepository>();
            container.Register<IPricePlanRepository,PricePlanRepository>();
            container.Register<IOrganizationRepository,OrganizationRepository>();
            container.Register<IProductRepository,ProductRepository>();
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ISupplierService, SupplierService>();
            container.Register<IOrganizationService, OrganizationService>();
            container.Register<IPricePlanService, PricePlanService>();
            container.Register<ISectionService, SectionService>();
            container.Register<IStockService, StockService>();
            container.Register<IProductService, ProductService>();
            container.Register<IPurchaseServiceOrganization, PurchaseService>();
            container.Register<IPurchaseProductService, PurchaseProductService>();
        }
    }
}
