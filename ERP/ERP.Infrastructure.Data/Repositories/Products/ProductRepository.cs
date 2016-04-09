using System;
using System.Collections.Generic;
using ERP.Domain.Common;
using ERP.Domain.Entities.Products;
using ERP.Domain.Interfaces.Products;
using ERP.Infrastructure.Data.Repositories.Base;

namespace ERP.Infrastructure.Data.Repositories.Products
{
    public class ProductRepository: RepositoryOrganizationBase<Product>, IProductRepository
    {
        public ProductRepository(IPurchaseUnitOfWork uow) : base(uow)
        {
            
        }

        public IEnumerable<Product> InStock(Guid organizationId)
        {
            //Todo Implementar a busca de produtos em estoque pegando o repositório de StockProduct
            throw  new NotImplementedException("Ainda não disponível");
        }
    }
}
