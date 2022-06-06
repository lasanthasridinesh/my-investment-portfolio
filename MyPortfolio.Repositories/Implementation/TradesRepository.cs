using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPortfolio.Repositories.Implementation
{
    public class TradesRepository : ITradesRepository
    {
        private readonly static ConcurrentDictionary<DateTime, IList<Trade>>
            tradesTable = new();

        public TradesRepository()
        {
            if (tradesTable.IsEmpty)
            {
                var data = JsonSerializer.Deserialize<IList<Trade>>(
                    File.ReadAllText(@"..\MockData\" + "trade-data.json"));
                if (data != null)
                {
                    foreach (var dataItem in data)
                    {
                        if (tradesTable.ContainsKey(dataItem.TradeDate))
                        {
                            tradesTable[dataItem.TradeDate].Add(dataItem);
                        }
                        else
                        {
                            tradesTable[dataItem.TradeDate] = new List<Trade>();
                        }
                    }
                }
            }
        }

        public IList<Trade>? GetAllTrades()
        {
            var trades = new List<Trade>();

            foreach (var tradeList in tradesTable.Values)
            {
                trades.AddRange(tradeList);
            }

            return trades;
        }

        public IList<Trade>? GetTradesFor(DateTime date)
        {
            return tradesTable.ContainsKey(date) ? tradesTable[date.Date] : null;
        }
    }
}
