using System;
using System.Collections.Generic;

namespace Task2.Logic
{
    /// <summary>
    /// Represents the binary search tree of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class BinarySearchTree<T>
    {
        private Node<T> _root;
        private readonly IComparer<T> _iComparer;

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class
        /// with a specified IComparer.
        /// </summary>
        /// <param name="iComparer">IComparer.</param>
        public BinarySearchTree(IComparer<T> iComparer)
        {
            _iComparer = iComparer;
        }

        /// <summary>
        /// Inserts the new element to the tree.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the element is already in the tree.
        /// </exception>
        /// <param name="key">The element.</param>
        public void Insert(T key)
        {
            var x = _root;
            Node<T> y = null;

            while (x != null)
            {
                var compare = _iComparer.Compare(key, x.Key);
                if (compare == 0)
                    throw new ArgumentException("The element is already in the tree!");

                y = x;
                x = compare < 0 ? x.Left : x.Right;
            }

            var newNode = new Node<T>(key);

            if (y == null)
                _root = newNode;
            else
            {
                if (_iComparer.Compare(key, y.Key) < 0)
                    y.Left = newNode;
                else
                    y.Right = newNode;
            }
        }

        /// <summary>
        /// Removes the element from the tree.
        /// </summary>
        ///  /// <exception cref="ArgumentException">
        /// Thrown if there is no such element in the tree.
        /// </exception>
        /// <param name="key">The element.</param>
        public void Remove(T key)
        {
            var x = _root;
            Node<T> y = null;

            while (x != null)
            {
                var compare = _iComparer.Compare(key, x.Key);
                if (compare == 0)
                    break;

                y = x;
                x = compare < 0 ? x.Left : x.Right;
            }

            if (x == null)
                throw new ArgumentException("No such element in the tree!");

            if (x.Right == null)
            {
                if (y == null)
                    _root = x.Left;
                else
                {
                    if (x == y.Left)
                        y.Left = x.Left;
                    else
                        y.Right = x.Left;
                }
            }
            else if (x.Left == null)
            {
                if (y == null)
                    _root = x.Right;
                else
                {
                    if (x == y.Right)
                        y.Right = x.Right;
                    else
                        y.Left = x.Right;
                }
            }
            else
            {
                var leftmost = x.Right;
                y = null;

                while (leftmost.Left != null)
                {
                    y = leftmost;
                    leftmost = leftmost.Left;
                }

                if (y != null)
                    y.Left = leftmost.Right;
                else
                    x.Right = leftmost.Right;

                x.Key = leftmost.Key;
            }
        }

        /// <summary>
        /// Provides the preorder traversal of the tree.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        public IEnumerable<T> Preorder()
        {
            var nodes = new Stack<Node<T>>();

            nodes.Push(_root);

            while (nodes.Count > 0)
            {
                var node = nodes.Pop();
                if (node != null)
                {
                    nodes.Push(node.Right);
                    nodes.Push(node.Left);
                    yield return node.Key;
                }
            }
        }

        /// <summary>
        /// Provides the inorder traversal of the tree.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        public IEnumerable<T> Inorder()
        {
            var stack = new Stack<Node<T>>();
            var node = _root;

            while (true)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                if (stack.Count == 0)
                    break;

                node = stack.Pop();
                yield return node.Key;
                node = node.Right;
            }
        }

        /// <summary>
        /// Provides the postorder traversal of the tree.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        public IEnumerable<T> Postorder()
        {
            var stack = new Stack<Node<T>>();
            var node = _root;
            Node<T> ancestor = null;

            while (true)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                if (stack.Count == 0)
                    break;

                node = stack.Peek();

                if (node.Right != null && node.Right != ancestor)
                    node = node.Right;
                else
                {
                    yield return node.Key;
                    ancestor = node;
                    node = null;
                    stack.Pop();
                }
            }
        }
    }
}
