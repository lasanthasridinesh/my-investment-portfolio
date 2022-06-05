using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Services.Interfaces;
using MyPortfolio.UserInterface.ViewModels;

namespace MyPortfolio.UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
            "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TradesController> _logger;
        private readonly ITradeService _tradesService;

        public TradesController(ILogger<TradesController> logger,
            ITradeService tradeService)
        {
            _logger = logger;
            _tradesService = tradeService;
        }

        [HttpGet]
        public IEnumerable<TradeVM> GetByDate(DateTime tradeDate)
        {
            var tradeData = _tradesService.GetTradesByDate(tradeDate.Date);
            var tradeViewModels = new List<TradeVM>();
            if(tradeData != null)
            {
                foreach(var dto in tradeData)
                {
                    tradeViewModels.Add(TradeVM.GetInstance(dto));
                }
            }
            return tradeViewModels;
        }
    }
}