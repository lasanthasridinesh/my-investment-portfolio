using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Implementation;
using System.Collections.Concurrent;

namespace MyPortfolio.Repositories.Tests
{
    [TestClass]
    public class TradeRepositoryTests
    {
        private readonly TradesRepository _tradesRepository;
        private readonly string TEST_DATA_FILE_PATH = @"test-data.json";

        public TradeRepositoryTests()
        {
            _tradesRepository = new TradesRepository(TEST_DATA_FILE_PATH);
        }

        [TestMethod]
        public void GetAllTrades_ReturnsTrades()
        {
            //Arrange

            //Act
            var trades = _tradesRepository.GetAllTrades();

            //Assert
            Assert.IsNotNull(trades);
            Assert.IsTrue(trades.Count == 2);
            var trade1 = trades.Where(t => t.UserId == "user001").FirstOrDefault();
            var trade2 = trades.Where(t => t.UserId == "user002").FirstOrDefault();

            Assert.IsNotNull(trade1);
            Assert.AreEqual(trade1.Ticker, "IBM1");
            Assert.AreEqual(trade1.BuyOrSell, "Buy");
            Assert.AreEqual(trade1.Quantity, 10);
            Assert.AreEqual(trade1.UnitPrice, 50.55M);
            Assert.AreEqual(trade1.TotalCost, 505.50M);
            Assert.AreEqual(trade1.TradeDate, new DateTime(2001, 01, 01));

            Assert.IsNotNull(trade2);
            Assert.AreEqual(trade2.Ticker, "IBM2");
            Assert.AreEqual(trade2.BuyOrSell, "Sell");
            Assert.AreEqual(trade2.Quantity, 5);
            Assert.AreEqual(trade2.UnitPrice, 55.55M);
            Assert.AreEqual(trade2.TotalCost, 277.75M);
            Assert.AreEqual(trade2.TradeDate, new DateTime(2001, 01, 02));
        }
    }
}