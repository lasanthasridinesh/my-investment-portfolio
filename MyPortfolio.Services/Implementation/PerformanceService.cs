using MyPortfolio.Connectors.Interfaces;
using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using MyPortfolio.Services.DTO;
using MyPortfolio.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.Implementation
{
    public class PerformanceService : IPerformanceService
    {
        private readonly ITradesRepository _tradesRepository;
        private readonly IAlphaVantageConnector _alphaVantageConnector;

        private readonly Dictionary<string, PriceDTO> prices = new();
        private readonly Dictionary<string, IList<Trade>> tradesBySymbol = new();

        public PerformanceService(ITradesRepository tradesRepository,
            IAlphaVantageConnector alphaVantageConnector)
        {
            _tradesRepository = tradesRepository;
            _alphaVantageConnector = alphaVantageConnector;
        }
        public async Task<IList<PerformanceItemDTO>> GetPerformanceAsync()
        {
            var trades = _tradesRepository.GetAllTrades();
            var performanceData = new List<PerformanceItemDTO>();

            if (trades != null)
            {
                foreach (var item in trades)
                {
                    if (item.Ticker != null)
                    {
                        if (tradesBySymbol.ContainsKey(item.Ticker))
                        {
                            tradesBySymbol[item.Ticker].Add(item);
                        }
                        else
                        {
                            tradesBySymbol.Add(item.Ticker, new List<Trade>());
                        }
                    }
                }
            }

            await EnrichPricesAsync((IList<string?>?)tradesBySymbol.Keys.ToList());

            foreach (var pair in tradesBySymbol)
            {
                var cost = pair.Value.Sum(t => t.TotalCost);
                var quantity = pair.Value.Sum(t => t.Quantity);
                var price = prices[pair.Key].Price;
                var previousClose = prices[pair.Key].PreviousClose;
                var marketValue = quantity * price;
                performanceData.Add(new PerformanceItemDTO()
                {
                    Ticker = pair.Key,
                    Cost = cost,
                    Quantity = quantity,
                    Price = price,
                    MarketValue = marketValue,
                    PreviousClose = previousClose,
                    DailyPandL = (price - previousClose) * quantity,
                    InceptionPandL = marketValue - cost
                });
            }

            return performanceData;
        }
        private async Task EnrichPricesAsync(IList<string?>? symbols)
        {
            if (symbols == null) return;
            foreach (var item in symbols)
            {
                if (item == null) continue;
                var quoteResponse = await _alphaVantageConnector.GetQuoteBySymbolAsync(item);
                if (quoteResponse != null)
                {
                    prices[item] = new PriceDTO
                    {
                        Price = decimal.Parse(quoteResponse.GlobalQuote?.Price ?? "0"),
                        PreviousClose = decimal.Parse(quoteResponse.GlobalQuote?.Priviousclose ?? "0")
                    };
                }
            }
        }
    }
}
