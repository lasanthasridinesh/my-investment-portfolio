using MyPortfolio.Connectors.DTO;
using System.Text.Json;

namespace MyPortfolio.Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var jsonText = "{\n    \"Global Quote\": {\n        \"01. symbol\": \"IBM\",\n        \"02. open\": \"140.2600\",\n        \"03. high\": \"142.5794\",\n        \"04. low\": \"139.7400\",\n        \"05. price\": \"141.1800\",\n        \"06. volume\": \"4352213\",\n        \"07. latest trading day\": \"2022-06-03\",\n        \"08. previous close\": \"140.1500\",\n        \"09. change\": \"1.0300\",\n        \"10. change percent\": \"0.7349%\"\n    }\n}";

            //Act
            var quoteResponse = JsonSerializer.Deserialize<AVQuoteResponseDTO>(jsonText);

            //Assert
            Assert.IsNotNull(quoteResponse);
        }
    }
}