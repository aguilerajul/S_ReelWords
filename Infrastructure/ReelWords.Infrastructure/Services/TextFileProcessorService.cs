using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;

namespace ReelWords.Infrastructure.Services
{
    public class TextFileProcessorService : ITextFileProcessor<Trie>
    {
        public Trie ConvertToObject(string filePath)
        {
			var trie = new Trie();
			try
			{
				using(var sr =  new StreamReader(filePath))
				{ 
					while(!sr.EndOfStream)
					{
						var line = sr.ReadLine();
						trie.Insert(line);
                    }
				}

				return trie;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
