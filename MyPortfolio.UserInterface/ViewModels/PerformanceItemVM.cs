using MyPortfolio.Services.DTO;

namespace MyPortfolio.UserInterface.ViewModels
{
    public class PerformanceItemVM
    {
        public string? Ticker { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal DailyPandL { get; set; }
        public decimal InceptionPandL { get; set; }

        public static PerformanceItemVM GetInstance(PerformanceItemDTO dto)
        {
            return new PerformanceItemVM()
            {
                Ticker = dto.Ticker,
                Cost = dto.Cost,
                Quantity = dto.Quantity,
                Price = dto.Price,
                MarketValue = dto.MarketValue,
                PreviousClose = dto.PreviousClose,
                DailyPandL = dto.DailyPandL,
                InceptionPandL = dto.InceptionPandL
            };
        }
    }
}
