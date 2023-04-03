using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Repositories
{
    public class ReelsRepository : IRepositoryBase<Reel>
    {
        private readonly RepositoryDbContext context;

        public ReelsRepository(RepositoryDbContext context)
        {
            this.context = context;
        }

        public async Task<Reel> AddAsync(Reel item)
        {
            var newReel = new Reel(item.Name);
            this.context.Reels.Attach(newReel);
            await this.context.SaveChangesAsync();
            return newReel;
        }

        public async Task<IEnumerable<Reel>> GetListAsync()
        {
            return await Task.Run(() => this.context.Reels);
        }
    }
}
