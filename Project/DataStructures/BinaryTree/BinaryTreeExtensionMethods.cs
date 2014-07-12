using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class BinaryTreeExtensionMethods
    {
        #region Add
        public static void Add<T>(this BinaryTree<T> tree, T value) where T : IComparable<T>
        {
            if (tree.Root == null)
            {
                tree.Root = new Node<T>(value);
                tree.Count++;

                return;
            }

            tree.AddTo(tree.Root, value);
            tree.Count++;
        }

        private static void AddTo<T>(this BinaryTree<T> tree, Node<T> node, T value) where T : IComparable<T>
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                    return;
                }

                tree.AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                    return;
                }

                tree.AddTo(node.Right, value);
            }
        }
        #endregion

        #region Contains
        /// <summary>
        /// This will only find the first occurance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Contains<T>(this BinaryTree<T> tree, T value) where T : IComparable<T>
        {
            Node<T> parent;

            return tree.FindWithParent(value, out parent) != null;
        }

        public static Node<T> FindWithParent<T>(this BinaryTree<T> tree, T value, out Node<T> parent) where T : IComparable<T>
        {
            var current = tree.Root;
            parent = null;

            while (current != null)
            {
                var result = current.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else { break; }
            }

            return current;
        }
        #endregion

        #region Remove
        public static bool Remove<T>(this BinaryTree<T> tree, T value) where T : IComparable<T>
        {
            Node<T> parent;

            var current = tree.FindWithParent(value, out parent);

            if (current == null) return false;

            tree.Count--;

            // Case 1: If current has no right child, then current's left replaces current
            if (current.Right == null)
            {
                if (parent == null) tree.Root = current.Left;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0) parent.Left = current.Left;
                    else if (result < 0) parent.Right = current.Left;
                }
            }

            // Case 2: If current's right child has no left child, then current's right child replaces current
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null) tree.Root = current.Right;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0) parent.Left = current.Right;
                    else if (result < 0) parent.Right = current.Right;
                }
            }

            // Case 3: If current's right child has a left child, replace current with current's right child's left-most child
            else
            {
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftMostParent.Left = leftMost.Right;

                // assign leftmost's left and right to current's left and right children
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null) tree.Root = leftMost;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0) parent.Left = leftMost;
                    else if (result < 0) parent.Right = leftMost;
                }
            }

            return true;
        }
        #endregion

        #region Traversal: Pre-Order
        public static IEnumerable<T> PreOrderTraverse<T>(this BinaryTree<T> tree) where T : IComparable<T>
        {
            var list = new List<T>();

            return tree.PreOrderTraverse(tree.Root, list);
        }

        public static IEnumerable<T> PreOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current, IList<T> list) where T : IComparable<T>
        {
            if (current == null) return null;

            list.Add(current.Value);
            tree.PreOrderTraverse(current.Left, list);
            tree.PreOrderTraverse(current.Right, list);

            return list;
        }

        public static void PreOrderTraverse<T>(this BinaryTree<T> tree, Action<T> action) where T : IComparable<T>
        {
            tree.PreOrderTraverse(tree.Root, action);
        }

        public static void PreOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current, Action<T> action) where T : IComparable<T>
        {
            if (current == null) return;

            action(current.Value);
            tree.PreOrderTraverse(current.Left, action);
            tree.PreOrderTraverse(current.Right, action);
        }
        #endregion

        #region Traversal: In-Order
        public static IEnumerable<T> InOrderTraverse<T>(this BinaryTree<T> tree) where T : IComparable<T>
        {
            var current = tree.Root;

            var list = new List<T>();

            tree.InOrderTraverse(current.Left);
            list.Add(current.Value);
            tree.InOrderTraverse(current.Right);

            return list;
        }

        public static IEnumerable<T> InOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current) where T : IComparable<T>
        {
            if (current == null) return null;

            var list = new List<T>();

            tree.InOrderTraverse(current.Left);
            list.Add(current.Value);
            tree.InOrderTraverse(current.Right);

            return list;
        }

        public static void InOrderTraverse<T>(this BinaryTree<T> tree, Action<T> action) where T : IComparable<T>
        {
            tree.InOrderTraverse(tree.Root, action);
        }

        public static void InOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current, Action<T> action) where T : IComparable<T>
        {
            if (current == null) return;

            tree.InOrderTraverse(current.Left, action);
            action(current.Value);
            tree.InOrderTraverse(current.Right, action);
        }
        #endregion

        #region Traversal: Post-Order
        public static IEnumerable<T> PostOrderTraverse<T>(this BinaryTree<T> tree) where T : IComparable<T>
        {
            var current = tree.Root;

            var list = new List<T>();

            tree.PostOrderTraverse(current.Left);
            tree.PostOrderTraverse(current.Right);
            list.Add(current.Value);

            return list;
        }

        public static IEnumerable<T> PostOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current) where T : IComparable<T>
        {
            if (current == null) return null;

            var list = new List<T>();

            tree.PostOrderTraverse(current.Left);
            tree.PostOrderTraverse(current.Right);
            list.Add(current.Value);

            return list;
        }

        public static void PostOrderTraverse<T>(this BinaryTree<T> tree, Action<T> action) where T : IComparable<T>
        {
            tree.PostOrderTraverse(tree.Root, action);
        }

        public static void PostOrderTraverse<T>(this BinaryTree<T> tree, Node<T> current, Action<T> action) where T : IComparable<T>
        {
            if (current == null) return;

            tree.PostOrderTraverse(current.Left, action);
            tree.PostOrderTraverse(current.Right, action);
            action(current.Value);
        }
        #endregion
    }
}
