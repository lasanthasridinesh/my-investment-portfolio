using MyPortfolio.Connectors.DTO;
using MyPortfolio.Connectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPortfolio.Connectors.Implementation
{
    public class AlphaVantageConnector : IAlphaVantageConnector
    {
        private static readonly string ALPHAVANTAGE_QUOTE_URL = "https://www.alphavantage.co/";
        public async Task<AVQuoteResponseDTO?> GetQuoteBySymbolAsync(string symbol)
        {
            //try
            //{
            //    using var client = GetHttpClient(ALPHAVANTAGE_QUOTE_URL);
            //    HttpResponseMessage response = await client.GetAsync("query?function=GLOBAL_QUOTE&symbol=" + symbol + "&apikey=WPH7BD3Z21TXEIWM");
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var json = await response.Content.ReadAsStringAsync();
            //        var result = JsonSerializer.Deserialize<AVQuoteResponseDTO>(json);
            //        return result;
            //    }

            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return null;
            //}
            Random randomGenerator = new();
            return new AVQuoteResponseDTO()
            {
                GlobalQuote = new GlobalQuote()
                {
                    Symbol = symbol,
                    Price = (randomGenerator.Next(1000, 10000) / 100.00).ToString(),
                    Priviousclose = (randomGenerator.Next(1000, 10000) / 100.00).ToString()
                }
            };
        }

        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
