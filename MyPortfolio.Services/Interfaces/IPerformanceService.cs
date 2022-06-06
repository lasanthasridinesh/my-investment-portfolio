using MyPortfolio.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services.Interfaces
{
    public interface IPerformanceService
    {
        Task<IList<PerformanceItemDTO>> GetPerformanceAsync();
    }
}
