using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class ReelService : IReelsService
    {
        public Reel GenerateFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reel> GenerateListFromFile(string filePath)
        {
            IList<Reel> reels = new List<Reel>();
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        reels.Add(new Reel(sr.ReadLine()));
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
