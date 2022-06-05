using MyPortfolio.DBModel.DOM;
using MyPortfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Repositories.Implementation
{
    internal class TradesRepository : BaseRepository<Trade, int>, ITradesRepository
    {
        internal TradesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
