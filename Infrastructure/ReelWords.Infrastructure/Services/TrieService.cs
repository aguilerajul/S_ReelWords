using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class TrieService: ITrieService
    {
        public Trie GenerateFromFile(string filePath)
        {
            var trie = new Trie();
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream) 
                        trie.Insert(sr.ReadLine());
                }
                return trie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Trie> GenerateListFromFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
