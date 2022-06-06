using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Services.Interfaces;
using MyPortfolio.UserInterface.ViewModels;

namespace MyPortfolio.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly ITradeService _tradesService;
        private readonly IPerformanceService _performanceService;

        public TradesController(ITradeService tradeService,
            IPerformanceService performanceService)
        {
            _tradesService = tradeService;
            _performanceService = performanceService;
        }

        [HttpGet]
        public IEnumerable<TradeVM> GetByDate(DateTime tradeDate)
        {
            var tradeViewModels = new List<TradeVM>();

            var tradeData = _tradesService.GetTradesByDate(tradeDate.Date);
            if (tradeData != null)
            {
                foreach (var dto in tradeData)
                {
                    tradeViewModels.Add(TradeVM.GetInstance(dto));
                }
            }

            return tradeViewModels;
        }

        [HttpGet("performance")]
        public async Task<IEnumerable<PerformanceItemVM>> GetPerformanceAsync()
        {
            IList<PerformanceItemVM> performanceDataToUI = new List<PerformanceItemVM>(); ;
            var performanceData = await _performanceService.GetPerformanceAsync();
            
            foreach(var dto in performanceData)
            {
                performanceDataToUI.Add(PerformanceItemVM.GetInstance(dto));
            }
            
            return performanceDataToUI;
        }
    }
}