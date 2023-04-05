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
                    var allText = sr.ReadToEnd();
                    var textsByLine = allText.Split('\r').ToList();
                    textsByLine = GenerateRandomSort(textsByLine).ToList();

                    foreach (var originalText in textsByLine)
                    {
                        var cleanText = originalText.Trim().Replace(" ", "");
                        var letters = new List<Letter>();
                        for (int i = 0; i < cleanText.Length; i++)
                        {
                            letters.Add(new Letter(cleanText[i], wordRow, i));
                        }
                        reels.Add(new Reel(originalText, letters));
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

        private IEnumerable<T> GenerateRandomSort<T>(IList<T> itemsToRandomize)
        {
            Random rand = new Random();
            var newSortedList = itemsToRandomize.OrderBy(_ => rand.Next()).ToList();
            return newSortedList;
        }
    }
}
