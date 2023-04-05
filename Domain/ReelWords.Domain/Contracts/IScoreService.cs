using ReelWords.Domain.Entities;

namespace ReelWords.Domain.Contracts
{
    public interface IScoreService : IFileServiceBase<Score>
    {
        IEnumerable<Score> GetWordScore(string word, IEnumerable<Score> scores);
    }
}
