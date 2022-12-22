using BookRecordsManager.Application.Interfaces;
using BookRecordsManager.Infra.InputDataHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Infra.InputDataFormatters;

namespace BookRecordsManager.Infra
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IInputDataHandler, JsonInputDataHandler>();
            services.AddScoped<IInputDataFormatter, DefaultInputDataFormatter>();
            return services;
        }
    }
}
