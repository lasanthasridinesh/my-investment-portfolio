using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Repositories.Implementation
{
    internal class TradesRepository : ITradesRepository
    {
        public IEnumerable<Trade> GetTradesFor(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
