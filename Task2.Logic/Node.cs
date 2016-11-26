namespace Task2.Logic
{
    /// <summary>
    /// Represents the tree node of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The key of the node.
        /// </summary>
        public T Key { get; set; }

        /// <summary>
        /// A reference to the left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// A reference to the right node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class
        /// with a specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public Node(T key)
        {
            Key = key;
            Left = null;
            Right = null;
        }
    }
}
