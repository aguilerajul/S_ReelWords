using FluentAssertions;
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
            trie.Search(testWord).Should().BeTrue();
        }

        [Theory]
        [InlineData("paralllel")]
        [InlineData("duel")]
        public void TrieDeleteTest(string testWord)
        {
            Trie trie = new Trie();
            trie.Insert(testWord);

            trie.Search(testWord).Should().BeTrue();

            trie.Delete(testWord);
            trie.Search(testWord).Should().BeFalse();
        }
    }
}