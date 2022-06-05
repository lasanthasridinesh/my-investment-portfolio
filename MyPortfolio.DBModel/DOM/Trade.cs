using Microsoft.AspNetCore.Identity;
using MyPortfolio.DBModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DBModel.DOM
{
    public class Trade
    {
        public string? UserId { get; set; }
        public string? Ticker { get; set; }
        public DateTime TradeDate { get; set; }
        public string? BuyOrSell { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; set; }
    }
}
