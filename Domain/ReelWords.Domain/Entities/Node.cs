namespace ReelWords.Domain.Entities
{
    public class Node
    {
        public Node? Parent { get; private set; }
        public IList<Node> Childs { get; private set; } = new List<Node>();
        public char Value { get; private set; }
        public int Depth { get; private set; }

        public Node(char value, int depth, Node? parent = null)
        {
            Value = value;
            Depth = depth;
            Parent = parent;
        }

        /// <summary>
        /// Validate if the current node has branch childs
        /// </summary>
        /// <returns>bool</returns>
        public bool IsBranch() => Childs.Count == 0;

        /// <summary>
        /// Search the child element based on the character send
        /// </summary>
        /// <param name="c">character or keyword</param>
        /// <returns>Node</returns>
        public Node SearchChild(char c) => Childs.FirstOrDefault(child => child.Value == c);

        /// <summary>
        /// Remove a child
        /// </summary>
        /// <param name="c">character or keyword</param>
        public void RemoveChild(char c)
        {
            for (int i = 0; i < Childs.Count; i++)
            {
                if (Childs[i].Value == c) Childs.RemoveAt(i);
            }
        }

        /// <summary>
        /// Add a new child
        /// </summary>
        /// <param name="node">Node item</param>
        public void AddChild(Node node) => Childs.Add(node);
    }
}
