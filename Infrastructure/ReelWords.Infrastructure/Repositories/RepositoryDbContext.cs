using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReelWords.Infrastructure.Repositories.EntityConfiguration;

namespace ReelWords.Infrastructure.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Domain.Entities.Score> Scores { get; set; }
        public DbSet<Domain.Entities.Reel> Reels { get; set; }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReelEntityConfiguration());
        }

        public void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<RepositoryDbContext>();
                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                    Seeder.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<RepositoryDbContext>>();
                    logger.LogError(ex, "Something get wrong trying to create and seed the database.");
                }
            }
        }
    }
}
