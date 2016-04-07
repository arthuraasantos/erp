using System;
using ERP.Domain.Interfaces.Products.Stocks;
using ERP.Services.PurchaseServices.Converters.Products.Stocks;
using ERP.Services.PurchaseServices.Dtos.Stocks;
using ERP.Services.PurchaseServices.Interfaces.Products.Stocks;

namespace ERP.Services.PurchaseServices.Services.Products.Stocks
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly StockNewDtoConverterOrganizationEntity _converterStockNewDto;
        private readonly StockEditDtoConverterOrganizationEntity _converterStockEditDto;
        private readonly StockDtoConverterOrganizationEntity _converterStockDto;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _converterStockDto = new StockDtoConverterOrganizationEntity();
            _converterStockEditDto = new StockEditDtoConverterOrganizationEntity();
            _converterStockNewDto = new StockNewDtoConverterOrganizationEntity();
        }

        public Guid Create(StockNewDto newStock, Guid organizationId)
        {
            try
            {
                if (!IsValidNewStock(newStock)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");
                newStock.OrganizationId = organizationId;
                var stock = _converterStockNewDto.Convert(newStock, null);

                _stockRepository.Save(stock);
                _stockRepository.Execute();

                return stock.Id;
            }
            catch (Exception ex)
            {
                //ToDo Implementar log de erros 
                throw new Exception($"Erro ao criar estoque:  {ex.Message} ");
            }
        }

  
        public StockDto Get(Guid id)
        {
            try
            {
                var stock = _stockRepository.Get(id);
                var stockDto = _converterStockDto.Convert(stock, null);

                return stockDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter estoque: {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var pricePlan = _stockRepository.Get(id);
                _stockRepository.Delete(pricePlan);
                _stockRepository.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar estoque: {ex.Message}");
            }
        }

        public void Update(StockEditDto editStock)
        {
            if (IsValidEditStock(editStock)) throw new ArgumentNullException($"Um campo obrigatório não foi preenchido");

            var stock = _converterStockEditDto.Convert(editStock, null);
            _stockRepository.Save(stock);
        }

        private static bool IsValidNewStock(StockNewDto newStock)
        {
            return !string.IsNullOrWhiteSpace(newStock.Description);
        }

        private static bool IsValidEditStock(StockEditDto editStock)
        {
            return !string.IsNullOrWhiteSpace(editStock.Description);
        }
    }
}
