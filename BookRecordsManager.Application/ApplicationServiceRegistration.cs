using System.Reflection;
using BookRecordsManager.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookRecordsManager.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //TODO: add any extra application services here as you see fit
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
