using MyPortfolio.Repositories.Interfaces;
using MyPortfolio.Services.DTO;
using MyPortfolio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.Implementation
{
    public class TradeService : ITradeService
    {
        private readonly ITradesRepository _tradesRepository;

        public TradeService(ITradesRepository tradesRepository)
        {
            _tradesRepository = tradesRepository;
        }

        public IList<TradeDTO> GetTradesByDate(DateTime date)
        {
            IList<TradeDTO> tradeDTOs = new List<TradeDTO>();
            var trades = _tradesRepository.GetTradesFor(date.Date);
            if(trades != null)
            {
                foreach(var item in trades)
                {
                    tradeDTOs.Add(TradeDTO.GetInstance(item));
                }
            }
            return tradeDTOs;
        }
    }
}
