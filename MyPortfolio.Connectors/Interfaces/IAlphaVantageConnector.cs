using MyPortfolio.Connectors.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Connectors.Interfaces
{
    public interface IAlphaVantageConnector
    {
        Task<AVQuoteResponseDTO?> GetQuoteBySymbolAsync(string symbol);
    }
}
