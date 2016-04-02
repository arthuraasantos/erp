using System;
using ERP.Domain.Entities.Products;

namespace ERP.Domain.Services.Products
{
    public static class ProductService
    {
        public static bool IsActive(Product entity) => entity.DeleteDate == null;

        public static double InStock(Product entity)
        {
            //ToDo Implementar este método para saber quantidade em estoque
            throw new NotImplementedException("Criar serviço para disponibilizar essa informação");
        } 
    }
}
