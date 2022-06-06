using Moq;
using MyPortfolio.Connectors.DTO;
using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using MyPortfolio.Services.Implementation;
using System.Text.Json;

namespace MyPortfolio.Services.Tests
{
    [TestClass]
    public class TradesServiceTests
    {
        private readonly Mock<ITradesRepository> _tradesRepositoryMock = new();
        private readonly TradeService _tradeService;

        public TradesServiceTests()
        {
            _tradeService = new TradeService(_tradesRepositoryMock.Object);
        }

        [TestMethod]
        public void GetTradesByDate_ValidDate_ReturnsDto()
        {
            //Arrange
            var tradesList = new List<Trade>()
            {
                new Trade(){Ticker="IBM1",UserId="user001",BuyOrSell="Buy",Quantity=10,UnitPrice=50.55M,TotalCost=505.50M,TradeDate=DateTime.Today}
            };
            _tradesRepositoryMock.Setup(tr => tr.GetTradesFor(DateTime.Today)).Returns(tradesList);

            //Act
            var tradeDTOs = _tradeService.GetTradesByDate(DateTime.Today);

            //Assert
            Assert.IsNotNull(tradeDTOs);
            Assert.AreEqual(tradeDTOs.Count, 1);
            var tradeDTO1 = tradeDTOs.Where(t => t.UserId == "user001").FirstOrDefault();

            Assert.IsNotNull(tradeDTO1);
            Assert.AreEqual(tradeDTO1.Ticker, "IBM1");
            Assert.AreEqual(tradeDTO1.BuyOrSell, "Buy");
            Assert.AreEqual(tradeDTO1.Quantity, 10);
            Assert.AreEqual(tradeDTO1.UnitPrice, 50.55M);
            Assert.AreEqual(tradeDTO1.TotalCost, 505.50M);
            Assert.AreEqual(tradeDTO1.TradeDate, DateTime.Today);
        }
    }
}