using ReelWords.Domain.Entities;
using Xunit;

namespace ReelWords.Tests
{
    public class TrieTests
    {
        [Theory]
        [InlineData("paralllel")]
        [InlineData("duel")]
        public void TrieInsertTest(string testWord)
        {
            Trie trie = new Trie();
            trie.Insert(testWord);
            Assert.True(trie.Search(testWord));
        }

        [Theory]
        [InlineData("paralllel")]
        [InlineData("duel")]
        public void TrieDeleteTest(string testWord)
        {
            Trie trie = new Trie();
            trie.Insert(testWord);
            Assert.True(trie.Search(testWord));
            trie.Delete(testWord);
            Assert.False(trie.Search(testWord));
        }
    }
}