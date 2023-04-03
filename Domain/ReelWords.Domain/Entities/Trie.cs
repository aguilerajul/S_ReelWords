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

        public Node Prefix(string s)
        {
            var current = _root;
            var found = current;
            foreach (var c in s)
            {
                current = current.SearchChild(c);
                if (current == null)
                    break;
                found = current;
            }
            return found;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.SearchChild('$') != null;
        }

        public void Insert(string s)
        {
            var prefix = Prefix(s);
            var current = prefix;
            for (int i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node(s[i], current.Depth + 1, current);
                current.AddChild(newNode);
                current = newNode;
            }
            current.AddChild(new Node('$', current.Depth + 1, current));
        }

        public void Delete(string s)
        {
            if(Search(s))
            {
                var node = Prefix(s).SearchChild('$');
                do
                {
                    var parent = node.Parent;
                    parent.RemoveChild(node.Value);
                    node = parent;
                } while (node.IsBranch());
            }
        }
    }
}