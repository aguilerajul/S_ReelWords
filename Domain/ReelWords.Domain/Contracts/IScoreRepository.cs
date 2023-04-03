using ReelWords.Domain.Entities;

namespace ReelWords.Domain.Contracts
{
    public interface IScoreRepository : IRepositoryBase<Score>
    {
        Task<Score?> GetByCharacterAsync(string character);
    }
}
