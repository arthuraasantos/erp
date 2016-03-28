using ERP.Domain.Entities.Products;

namespace ERP.Domain.Services.Products
{
    public static class ProductService
    {
        public static bool IsActive(Product entity) => entity.DeleteDate == null;

        public static double InStock(Product entity) => entity.StockProduct.Quantity;
    }
}
