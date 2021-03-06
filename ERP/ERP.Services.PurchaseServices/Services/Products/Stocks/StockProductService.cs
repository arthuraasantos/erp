﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Interfaces.Products.Stocks;
using ERP.Services.PurchaseServices.Converters.Products.StockProducts;
using ERP.Services.PurchaseServices.Dtos.StockProducts;
using ERP.Services.PurchaseServices.Interfaces.Products.Stocks;

namespace ERP.Services.PurchaseServices.Services.Products.Stocks
{
    public class StockProductService : IStockProductService
    {
        private readonly IStockProductRepository _stockProductRepository;
        private readonly StockProductNewDtoConverterOrganizationEntity _converterStockProductNewDto;
        private readonly StockProductEditDtoConverterOrganizationEntity _converterStockProductEditDto;
        private readonly StockProductDtoConverterOrganizationEntity _converterStockProductDto;

        public StockProductService(IStockProductRepository stockProductRepository)
        {
            _converterStockProductDto = new StockProductDtoConverterOrganizationEntity();
            _converterStockProductEditDto = new StockProductEditDtoConverterOrganizationEntity();
            _converterStockProductNewDto = new StockProductNewDtoConverterOrganizationEntity();
            _stockProductRepository = stockProductRepository;
        }

        public StockProductDto Get(Guid id, Guid organizationId)
        {
            try
            {
                var stockProduct = _stockProductRepository.Get(id, organizationId);
                if (stockProduct == null) throw new NullReferenceException();

                var stockProductDto = _converterStockProductDto.Convert(stockProduct, null);

                return stockProductDto;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Produto estoque não encontrado");

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter produto no estoque: {ex.Message}");
            }
        }

        public Guid Create(StockProductNewDto newStockProduct, Guid organizationId)
        {
            try
            {
                if (!IsValidNewStockProduct(newStockProduct)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newStockProduct.OrganizationId = organizationId;
                var stockProduct = _converterStockProductNewDto.Convert(newStockProduct, null);

                _stockProductRepository.Save(stockProduct);
                _stockProductRepository.Execute();

                return stockProduct.Id;
            }
           
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar produto no estoque:  {ex.Message} ");
            }
        }


        public void Delete(Guid id, Guid organizationId)
        {
            try
            {
                var stockProduct = _stockProductRepository.Get(id, organizationId);
                _stockProductRepository.Delete(stockProduct);
                _stockProductRepository.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar produto no estoque: {ex.Message}");
            }
        }

        public void Update(StockProductEditDto editStockProduct)
        {
            try
            {
                if (!IsValidEditStockProduct(editStockProduct)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

                var stock = _converterStockProductEditDto.Convert(editStockProduct, null);
                _stockProductRepository.Save(stock);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar produto no estoque: {ex.Message}");
            }

        }

        private static bool IsValidNewStockProduct(StockProductNewDto newStockProduct)
            => newStockProduct.Quantity > 0;

        private static bool IsValidEditStockProduct(StockProductEditDto editStockProduct) 
            => editStockProduct.Quantity > 0;
    }
}
