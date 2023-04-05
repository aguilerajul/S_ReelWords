using Microsoft.Extensions.Configuration;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class TrieService: ITrieService
    {
        private readonly IConfiguration _configuration;

        public TrieService(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }

        public Trie GenerateFromFile(string directoryPath)
        {
            var trie = new Trie();
            try
            {
                var trieFilePath = $"{directoryPath}{this._configuration.GetSection("ReelWords.FileNames")["trie"]}";
                using (var sr = new StreamReader(trieFilePath))
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
