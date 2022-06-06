using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPortfolio.Connectors.DTO
{
    public class GlobalQuote
    {
        [JsonPropertyName("01. symbol")]
        public string? Symbol { get; set; }
        [JsonPropertyName("05. price")]
        public string? Price { get; set; }
        [JsonPropertyName("08. previous close")]
        public string? Priviousclose { get; set; }
    }

    public class AVQuoteResponseDTO
    {
        [JsonPropertyName("Global Quote")]
        public GlobalQuote? GlobalQuote { get; set; }
    }
}
