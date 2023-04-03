using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Repositories
{
    public class Seeder
    {
        private readonly RepositoryDbContext _context;
        private readonly ITextFileProcessorService<Reel> _reelFileProcessorService;
        private readonly ITextFileProcessorService<Score> _scoreFileProcessorService;

        public Seeder(RepositoryDbContext context,
            ITextFileProcessorService<Reel> reelFileProcessorService,
            ITextFileProcessorService<Score> scoreFileProcessorService)
        {
            this._context = context;
            this._context.Database.EnsureCreated();
            this._reelFileProcessorService = reelFileProcessorService;
            this._scoreFileProcessorService = scoreFileProcessorService;
        }

        private static void CreateReels()
        {

        }
    }
}
