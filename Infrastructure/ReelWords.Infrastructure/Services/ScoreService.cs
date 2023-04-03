using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class ScoreService : IScoreService
    {
        public IEnumerable<Score> GenerateListFromFile(string filePath)
        {
            IList<Score> scores = new List<Score>();
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var scoreData = line.Split(' ');
                        scores.Add(new Score(scoreData[0], float.Parse(scoreData[1])));
                    }
                }
                return scores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Score IFileServiceBase<Score>.GenerateFromFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
