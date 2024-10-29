using Loja.Application.Services;
using Loja.Application.Services.IService;
using Loja.Data.Repositories;
using Loja.Data.Repositories.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Application.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;
        }

    }
}
