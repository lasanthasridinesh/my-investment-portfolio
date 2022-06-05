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
            Console.WriteLine("When you enter the start date and end date, application will\n" +
                "generate a set of JSON files with test data. " +
                "One JSON file will be generated per day.");


            EnterDateRange(Constants.DATE_FORMAT, out DateTime startDate);
            DateTime endDate = DateTime.Today;
            var numberOfDays = (endDate - startDate).TotalDays;
            var symbols = new List<string> { "A", "A.TRV", "B", "B.TRV",
                "C", "C.TRV", "IBM","TSCDF","TSCDY","GO","GOAC","GOOG",
                "GOODN","GOODLUCK.BSE","NKE","NKE.DEX","PU13.LON","MSA","MSACX",
                "DIS","DISA","DISAQ.BSE","TATACHEM.BSE","TATAINVEST.BSE","TATAMTRDVR.BSE",
                "DEMO","TESS","SPACEINCUBA.BSE"};
            var trades = new List<Trade>();

            for (var i = 0; i <= numberOfDays; i++)
            {

                foreach (var symbol in symbols)
                {
                    var dailyTradeCount = new Random().Next(1, 25);
                    for (var j = 0; j < dailyTradeCount; j++)
                    {
                        var quantity = RandomSupplier.Quantity();
                        var price = RandomSupplier.Price();
                        trades.Add(new Trade()
                        {
                            UserId = "user001",
                            BuyOrSell = RandomSupplier.BuyOrSell(),
                            Quantity = quantity,
                            Ticker = symbol,
                            UnitPrice = price,
                            TradeDate = startDate.AddDays(i),
                            TotalCost = Math.Round(quantity * price, 2)
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
