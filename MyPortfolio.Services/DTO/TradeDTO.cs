using MyPortfolio.DBModel.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.DTO
{
    public class TradeDTO
    {
        public string? UserId { get; set; }
        public string? Ticker { get; set; }
        public DateTime TradeDate { get; set; }
        public string? BuyOrSell { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; set; }

        public static TradeDTO GetInstance(Trade trade)
        {
            return new TradeDTO()
            {
                UserId = trade.UserId,
                Ticker = trade.Ticker,
                TradeDate = trade.TradeDate,
                BuyOrSell = trade.BuyOrSell,
                Quantity = trade.Quantity,
                UnitPrice = trade.UnitPrice,
                TotalCost = trade.TotalCost
            };
        }

        public static Trade ToTrade(TradeDTO dto)
        {
            return new Trade()
            {
                UserId = dto.UserId,
                Ticker = dto.Ticker,
                TradeDate = dto.TradeDate,
                BuyOrSell = dto.BuyOrSell,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                TotalCost = dto.TotalCost
            };
        }
    }
}
