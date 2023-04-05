using FluentAssertions;
using Newtonsoft.Json.Linq;
using ReelWords.Domain.Entities;
using Xunit;

namespace ReelWords.Tests
{
    public class NodeTests
    {
        private readonly Node _parentNode;

        public NodeTests()
        {
            _parentNode = new Node('^', 0);
        }

        [Theory]
        [InlineData('p', 0)]
        public void NodeAddChildTest(char value, int depth)
        {
            Node node = new Node(value, depth, null);
            node.AddChild(node);
            node.SearchChild(value).Should().NotBeNull();

            var nodeSearch = node.SearchChild(value);
            nodeSearch.Depth.Should().Be(depth);
            nodeSearch.Childs.Should().HaveCount(1);
            nodeSearch.Childs[0].Value.Should().Be(value);
        }

        [Theory]
        [InlineData('p')]
        public void NodeIsBranchTest(char value)
        {
            Node node = new Node(value, 0, null);
            node.IsBranch().Should().BeTrue();
        }

        [Theory]
        [InlineData("parallel")]
        public void NodeIsBranchFalsyTest(string word)
        {
            Node parentNode = new Node('*', 0);
            AddChildsForTest(word, parentNode);

            parentNode.IsBranch().Should().BeFalse();
        }

        [Theory]
        [InlineData("parallel")]
        public void NodeSearchChildTest(string word)
        {
            Node parentNode = new Node('*', 0);
            AddChildsForTest(word, parentNode);

            var searchChild = parentNode.SearchChild('l');
            searchChild.Should().NotBeNull();
        }

        [Theory]
        [InlineData("paralllel")]
        public void NodeRemoveChildTest(string word)
        {
            Node parentNode = new Node('*', 0);
            AddChildsForTest(word, parentNode);

            var childToRemove = 'l';
            foreach (var item in word.Where(w => w == childToRemove))
            {
                parentNode.RemoveChild(childToRemove);
            }
            var searchChild = parentNode.SearchChild(childToRemove);
            searchChild.Should().BeNull();
        }

        private static void AddChildsForTest(string word, Node parentNode)
        {
            for (int i = 0; i < word.Length; i++)
            {
                parentNode.AddChild(new Node(word[i], i, parentNode));
            }
        }
    }
}