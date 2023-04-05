using Microsoft.Extensions.Configuration;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IConfiguration _configuration;

        public ScoreService(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }

        public IEnumerable<Score> GenerateListFromFile(string directoryPath)
        {
            IList<Score> scores = new List<Score>();
            try
            {
                var scoresFilePath = $"{directoryPath}{this._configuration.GetSection("ReelWords.FileNames")["scores"]}";
                using (var sr = new StreamReader(scoresFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var scoreData = line.Split(' ');
                        scores.Add(new Score(scoreData[0], int.Parse(scoreData[1])));
                    }
                }
                return scores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Score> GetWordScore(string word, IEnumerable<Score> scores)
        {
            IList<Score> playerScores = new List<Score>();
            try
            {
                foreach (var c in word)
                {
                    playerScores.Add(scores.FirstOrDefault(s => s.Letter == c.ToString()));
                }

                return playerScores;
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
