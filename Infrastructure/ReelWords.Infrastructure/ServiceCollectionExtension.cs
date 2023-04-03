using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;
using ReelWords.Infrastructure.Repositories;
using ReelWords.Infrastructure.Services;

namespace ReelWords.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddRepositories(config)
                .AddServices(config);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(config.GetConnectionString("ReelsWords.DataBase")));

            services.AddSingleton<IRepositoryBase<Score>, ScoreRepository>();
            services.AddSingleton<IRepositoryBase<Reel>, ReelsRepository>();

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
