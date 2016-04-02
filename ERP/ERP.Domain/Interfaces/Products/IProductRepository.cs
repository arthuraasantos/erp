using System;
using System.Collections.Generic;
using ERP.Domain.Entities.Products;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces.Products
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> InStock(Guid organizationId);
    }
}
