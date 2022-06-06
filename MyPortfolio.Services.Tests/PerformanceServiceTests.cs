using Moq;
using MyPortfolio.Connectors.DTO;
using MyPortfolio.Connectors.Interfaces;
using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using MyPortfolio.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.Tests
{
    [TestClass]
    public class PerformanceServiceTests
    {
        private readonly PerformanceService _performanceService;
        private readonly Mock<IAlphaVantageConnector> _alphaVantageConnectorMock = new();
        private readonly Mock<ITradesRepository> _tradesRepositoryMock = new();

        public PerformanceServiceTests()
        {
            _performanceService = new PerformanceService(
                _tradesRepositoryMock.Object,
                _alphaVantageConnectorMock.Object);
        }

        [TestMethod]
        public async Task GetPerformanceAsync_ReturnsPerformanceDataAsync()
        {
            //Arrange
            var tradesList = new List<Trade>()
            {
                new Trade(){Ticker="IBM",UserId="user001",BuyOrSell="Buy",Quantity=10,UnitPrice=50.55M,TotalCost=505.50M,TradeDate=new DateTime(2001,01,01)},
                new Trade(){Ticker="IBM",UserId="user001",BuyOrSell="Sell",Quantity=5,UnitPrice=55.55M,TotalCost=-277.75M,TradeDate=new DateTime(2001,01,01)},
            };
            _tradesRepositoryMock.Setup(tr => tr.GetAllTrades()).Returns(tradesList);

            var quote = new AVQuoteResponseDTO()
            {
                GlobalQuote = new GlobalQuoteResponseDTO()
                {
                    Symbol = "IBM",
                    Price = "65.11",
                    Priviousclose = "63.25"
                }
            };
            _alphaVantageConnectorMock.Setup(av => av.GetQuoteBySymbolAsync("IBM"))
                .ReturnsAsync(quote);

            //Act
            var dtoList = await _performanceService.GetPerformanceAsync();

            //Assert
            Assert.IsNotNull(dtoList);
            Assert.AreEqual(dtoList.Count, 1);
            Assert.AreEqual(dtoList[0].Ticker, "IBM");
            Assert.AreEqual(dtoList[0].Quantity, 5);
            Assert.AreEqual(dtoList[0].Cost, 227.75M);
            Assert.AreEqual(dtoList[0].Price, 65.11M);
            Assert.AreEqual(dtoList[0].PreviousClose, 63.25M);
            Assert.AreEqual(dtoList[0].DailyPandL, 9.3M);
            Assert.AreEqual(dtoList[0].InceptionPandL, 97.80M);
        }
    }
}
