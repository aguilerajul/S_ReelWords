using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReelWords.Domain.Contracts;
using ReelWords.Infrastructure.Services;

namespace ReelWords.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddServices(config);

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<ITrieService, TrieService>();
            services.AddSingleton<IScoreService, ScoreService>();
            services.AddSingleton<IReelsService, ReelService>();

            return services;
        }
    }
}
