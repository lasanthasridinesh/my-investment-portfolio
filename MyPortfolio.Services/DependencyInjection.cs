using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Connectors.Implementation;
using MyPortfolio.Connectors.Interfaces;
using MyPortfolio.Repositories.Implementation;
using MyPortfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITradesRepository, TradesRepository>();
            services.AddScoped<IAlphaVantageConnector, AlphaVantageConnector>();
            return services;
        }
    }
}
