using ERP.Domain.Common;
using ERP.Domain.Interfaces.Suppliers;
using ERP.Infrastructure.Data.Context.Purchase;
using ERP.Infrastructure.Data.Repositories.Suppliers;
using ERP.Services.PurchaseServices.Interfaces;
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
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ISupplierService, SupplierService>();
        }
    }
}
