using MyPortfolio.Connectors.DTO;
using MyPortfolio.Connectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPortfolio.Connectors.Implementation
{
    public class AlphaVantageConnector : IAlphaVantageConnector
    {
        private static readonly string ALPHAVANTAGE_QUOTE_URL = "https://www.alphavantage.co/";
        private readonly HttpClient _httpClient;

        public AlphaVantageConnector(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ALPHAVANTAGE_QUOTE_URL);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<AVQuoteResponseDTO?> GetQuoteBySymbolAsync(string symbol)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("query?function=GLOBAL_QUOTE&symbol=" + symbol + "&apikey=WPH7BD3Z21TXEIWM");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<AVQuoteResponseDTO>(json);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Mock Data Method
        /// This will be used the test the system without connecting to AlphaVantage
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //public async Task<AVQuoteResponseDTO?> GetQuoteBySymbolAsync(string symbol)
        //{
        //    Random randomGenerator = new();
        //    return new AVQuoteResponseDTO()
        //    {
        //        GlobalQuote = new GlobalQuote()
        //        {
        //            Symbol = symbol,
        //            Price = (randomGenerator.Next(1000, 10000) / 100.00).ToString(),
        //            Priviousclose = (randomGenerator.Next(1000, 10000) / 100.00).ToString()
        //        }
        //    };
        //}
    }
}
