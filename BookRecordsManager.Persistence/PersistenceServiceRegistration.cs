using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Application.Interfaces.Persistence;
using BookRecordsManager.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRecordsManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //TODO: add any extra persistence services here as you see fit

            services.AddScoped<IBookRecordsRepository, BookRecordsRepository>();
            return services;
        }
    }
}
