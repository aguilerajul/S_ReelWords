using Microsoft.Extensions.Configuration;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class ReelService : IReelsService
    {
        private readonly IConfiguration _configuration;

        public ReelService(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }

        public Reel GenerateFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reel> GenerateListFromFile(string directoryPath)
        {
            IList<Reel> reels = new List<Reel>();
            try
            {
                var trieFilePath = $"{directoryPath}{this._configuration.GetSection("ReelWords.FileNames")["reels"]}";
                using (var sr = new StreamReader(trieFilePath))
                {
                    int wordRow = 0;
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var word = line.Trim().Replace(" ", "");
                        var letters = new List<Letter>();
                        for (int i = 0; i < word.Length; i++)
                        {
                            letters.Add(new Letter(word[i], wordRow, i));
                        }
                        reels.Add(new Reel(line, letters));
                        wordRow++;
                    }
                }
                return reels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
