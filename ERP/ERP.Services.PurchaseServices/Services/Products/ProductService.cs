using System;
using System.Linq;
using ERP.Domain.Interfaces.Products;
using ERP.Services.PurchaseServices.Converters.Products;
using ERP.Services.PurchaseServices.Dtos.Products;
using ERP.Services.PurchaseServices.Interfaces.Products;

namespace ERP.Services.PurchaseServices.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepositoryOrganization;
        private readonly ProductDtoConverterOrganizationEntity _converterProductDto;
        private readonly ProductEditDtoConverterOrganizationEntity _converterProductEditDto;
        private readonly ProductNewDtoConverterOrganizationEntity _converterProductNewDto;

        public ProductService(IProductRepository productRepositoryOrganization)
        {
            _productRepositoryOrganization = productRepositoryOrganization;
            _converterProductDto = new ProductDtoConverterOrganizationEntity();
            _converterProductEditDto = new ProductEditDtoConverterOrganizationEntity();
            _converterProductNewDto = new ProductNewDtoConverterOrganizationEntity();
        }

        public Guid Create(ProductNewDto newProduct, Guid organizationId)
        {
            try
            {
                if (!IsValidNewProduct(newProduct))
                    throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newProduct.OrganizationId = organizationId;
                var product = _converterProductNewDto.Convert(newProduct, null);

                _productRepositoryOrganization.Save(product);
                _productRepositoryOrganization.Execute();

                return product.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar produto:  {ex.Message} ");

            }
        }

        public ProductDto Get(Guid id, Guid organizationId)
        {
            try
            {
                var product = _productRepositoryOrganization.Get(id, organizationId);
                var productDto = _converterProductDto.Convert(product, null);

                return productDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter produto: {ex.Message}");
            }
        }

        public void Delete(Guid id, Guid organizationId)
        {
            try
            {
                var product = _productRepositoryOrganization.Get(id, organizationId);
                _productRepositoryOrganization.Delete(product);
                _productRepositoryOrganization.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar produto no estoque: {ex.Message}");
            }
        }

        public void Update(ProductEditDto editProduct)
        {
            try
            {
                if (IsValidEditProduct(editProduct)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var product = _converterProductEditDto.Convert(editProduct, null);
                _productRepositoryOrganization.Save(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        private static bool IsValidEditProduct(ProductEditDto editProduct)
            => !string.IsNullOrWhiteSpace(editProduct.Description);

        private static bool IsValidNewProduct(ProductNewDto newProduct)
            => !string.IsNullOrWhiteSpace(newProduct.Description);

    }
}
