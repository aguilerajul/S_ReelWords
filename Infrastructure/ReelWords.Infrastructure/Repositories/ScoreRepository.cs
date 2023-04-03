using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly RepositoryDbContext context;

        public ScoreRepository(RepositoryDbContext context)
        {
            this.context = context;
        }

        public async Task<Score> AddAsync(Score item)
        {
            var newUser = new Score(item.Character, item.Value);
            this.context.Scores.Attach(newUser);
            await this.context.SaveChangesAsync();

            return newUser;
        }

        public async Task<Score?> GetByCharacterAsync(string character)
        {
            return await Task.Run(() => this.context.Scores.FirstOrDefault(s => s.Character.Equals(character)));
        }

        public async Task<IEnumerable<Score>> GetListAsync()
        {
            return await Task.Run(() => this.context.Scores);
        }
    }
}
