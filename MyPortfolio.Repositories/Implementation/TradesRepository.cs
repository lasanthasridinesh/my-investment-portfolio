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
        private static ConcurrentDictionary<DateTime, IList<Trade>> tradesTable = new();
        private string DATA_FILE_PATH = @"..\MockData\" + "trade-data.json";

        public TradesRepository()
        {
            SetData();
        }

        /// <summary>
        /// This constructor will be used for testing
        /// </summary>
        /// <param name="testDataFilePath"></param>
        public TradesRepository(string testDataFilePath)
        {
            if (testDataFilePath != null) { DATA_FILE_PATH = testDataFilePath; }
            SetData();
        }

        private void SetData()
        {
            if (tradesTable.IsEmpty)
            {
                var data = JsonSerializer.Deserialize<IList<Trade>>(
                    File.ReadAllText(DATA_FILE_PATH));
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
                            tradesTable[dataItem.TradeDate] = new List<Trade>()
                            {
                                dataItem
                            };
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
