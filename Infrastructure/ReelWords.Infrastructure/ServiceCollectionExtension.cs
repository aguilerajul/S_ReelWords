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
                .AddRepositories(config);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(config.GetConnectionString("ReelsWords.DataBase")));

            services.AddSingleton<IScoreRepository, ScoreRepository>();
            services.AddSingleton<ITextFileProcessorService<Trie>, TextFileProcessorService>();

            return services;
        }
    }
}
