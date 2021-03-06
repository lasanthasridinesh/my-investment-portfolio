using MyPortfolio.DBModel.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Repositories.Interfaces
{
    public interface ITradesRepository
    {
        IList<Trade>? GetTradesFor(DateTime date);
        IList<Trade>? GetAllTrades();
    }
}
