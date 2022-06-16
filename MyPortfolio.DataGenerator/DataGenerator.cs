using MyPortfolio.DBModel.DOM;
using MyPortfolio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPortfolio.DataGenerator
{
    internal static class DataGenerator
    {
        internal static void Run()
        {
            Console.WriteLine("########################################################");
            Console.WriteLine("            My Portfolio - Test Data Generator");
            Console.WriteLine("########################################################");
            Console.WriteLine("When you enter the start date, application will\n" +
                "generate a JSON file with test data.");

            EnterDateRange(Constants.DATE_FORMAT, out DateTime startDate);
            DateTime endDate = DateTime.Today;
            var numberOfDays = (endDate - startDate).TotalDays;
            var symbols = new List<string> { "0OLD.LON", "IBM", "MSA", "MSACX", "NKE" };
            var trades = new List<Trade>();

            for (var i = 0; i <= numberOfDays; i++)
            {
                foreach (var symbol in symbols)
                {
                    var dailyTradeCount = new Random().Next(1, 3);
                    for (var j = 0; j < dailyTradeCount; j++)
                    {
                        var price = RandomSupplier.Price();
                        var buyOrSell = RandomSupplier.BuyOrSell();
                        var quantity = buyOrSell == "Buy" ? RandomSupplier.BuyQuantity() : RandomSupplier.SellQuantity();
                        var cost = Math.Round(quantity * price, 2);
                        trades.Add(new Trade()
                        {
                            UserId = "user001",
                            BuyOrSell = buyOrSell,
                            Quantity = quantity,
                            Ticker = symbol,
                            UnitPrice = price,
                            TradeDate = startDate.AddDays(i),
                            TotalCost = buyOrSell == "Buy" ? cost : (-cost)
                        });
                    }
                }
            }
            var dailyTradeDataJson = JsonSerializer.Serialize(trades);
            File.WriteAllText(@"..\..\..\..\MockData\" + "trade-data.json", dailyTradeDataJson);
        }

        private static void EnterDateRange(string DATE_FORMAT, out DateTime startDate)
        {
            startDate = default;
            try
            {
                Console.Write("Enter Start Date (" + DATE_FORMAT + ") : ");
                var startDateInput = Console.ReadLine();
                if (DateTime.TryParse(startDateInput, out DateTime startDateTimeValue))
                {
                    startDate = startDateTimeValue;
                }
                else
                {
                    throw new Exception("start date is not in correct format!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
