using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Repositories
{
    public class Seeder
    {
        private readonly RepositoryDbContext _context;
        private readonly IFileServiceBase<Reel> _reelService;
        private readonly IFileServiceBase<Score> _scoreService;

        public Seeder(RepositoryDbContext context,
            IFileServiceBase<Reel> reelService,
            IFileServiceBase<Score> scoreService)
        {
            this._context = context;
            this._context.Database.EnsureCreated();

            this._reelService = reelService;
            this._scoreService = scoreService;
        }

        private void CreateReels()
        {
            // var reels = _reelService.GenerateListFromFile()
        }
    }
}
