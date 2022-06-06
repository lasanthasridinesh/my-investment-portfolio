using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.DTO
{
    public class PerformanceItemDTO
    {
        public string? Ticker { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal DailyPandL { get; set; }
        public decimal InceptionPandL { get; set; }
    }
}
