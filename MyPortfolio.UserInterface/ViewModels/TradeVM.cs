using MyPortfolio.Services.DTO;

namespace MyPortfolio.UserInterface.ViewModels
{
    public class TradeVM
    {
        public string? Ticker { get; set; }
        public string? BuyOrSell { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; set; }

        public static TradeVM GetInstance(TradeDTO dto)
        {
            return new TradeVM()
            {
                Ticker = dto.Ticker,
                BuyOrSell = dto.BuyOrSell,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                TotalCost = dto.TotalCost
            };
        }
    }
}
