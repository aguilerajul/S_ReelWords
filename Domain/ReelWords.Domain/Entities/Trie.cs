using System;

namespace ReelWords.Domain.Entities
{
    public class Trie
    {
        private readonly Node _root;

        public Trie()
        {
            this._root = new Node('^', 0);
        }

        public Node Prefix(string word)
        {
            var current = _root;
            var found = current;
            foreach (var c in word)
            {
                current = current.SearchChild(c);
                if (current == null)
                    break;
                found = current;
            }
            return found;
        }

        public bool Search(string word)
        {
            var prefix = Prefix(word);
            return prefix.Depth == word.Length && prefix.SearchChild('$') != null;
        }

        public void Insert(string word)
        {
            var prefix = Prefix(word);
            var current = prefix;
            for (int i = current.Depth; i < word.Length; i++)
            {
                var newNode = new Node(word[i], current.Depth + 1, current);
                current.AddChild(newNode);
                current = newNode;
            }
            current.AddChild(new Node('$', current.Depth + 1, current));
        }

        public void Delete(string word)
        {
            if (Search(word))
            {
                var node = Prefix(word).SearchChild('$');
                do
                {
                    var parent = node.Parent;
                    if (parent != null)
                        parent.RemoveChild(node.Value);
                    node = parent;
                } while (node != null && node.IsBranch());
            }
        }
    }
}