using MyPortfolio.DBModel.DOM;
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
            Console.WriteLine("When you enter the start date and end date, application will\n" +
                "generate a set of JSON files with test data. " +
                "One JSON file will be generated per day.");

            var DATE_FORMAT = "yyyy-MM-dd";
            Console.Write("Enter Start Date (" + DATE_FORMAT + ") : ");
            var startDateInput = Console.ReadLine();
            var startDate = DateTime.Parse(startDateInput);
            var startDateString = startDate.Date.ToString(DATE_FORMAT);
            Console.Write("Enter End Date (" + DATE_FORMAT + ") : ");
            var endDateInput = Console.ReadLine();
            var endDate = DateTime.Parse(endDateInput);
            var endDateString = endDate.Date.ToString(DATE_FORMAT);
            Console.WriteLine(startDate + "  " + endDate);

            var numberOfDays = (endDate - startDate).TotalDays;
            var symbols = new List<string> { "A", "A.TRV", "B", "B.TRV", "C", "C.TRV" };

            for (var i = 0; i <= numberOfDays; i++)
            {
                var tradeDate = startDate.AddDays(i);
                var dailyTrades = new List<Trade>();
                foreach (var symbol in symbols)
                {
                    var dailyTradeCount = new Random().Next(1, 25);
                    for (var j = 0; j < dailyTradeCount; j++)
                    {
                        var quantity = RandomSupplier.Quantity();
                        var price = RandomSupplier.Price();
                        dailyTrades.Add(new Trade()
                        {
                            UserId = "user001",
                            BuyOrSell = RandomSupplier.BuyOrSell(),
                            Quantity = quantity,
                            Ticker = symbol,
                            UnitPrice = price,
                            TradeDate = tradeDate,
                            TotalCost = Math.Round(quantity * price,2)
                        });
                    }
                }

                var dailyTradeDataJson = JsonSerializer.Serialize(dailyTrades);
                File.WriteAllText(@"..\..\..\..\MockData\"+tradeDate.Date.ToString(DATE_FORMAT) + ".json", dailyTradeDataJson);
            }


        }
    }
}
