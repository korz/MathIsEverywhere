using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class Extensions
    {
        #region Traversal: Left-Walk
        public static IEnumerable<T> LeftWalkTraverse<T>(this BinaryTree<T> tree) where T : IComparable<T>
        {
            var stack = new Stack<T>();

            tree.LeftWalkTraverse(tree.Root, stack);

            return stack;
        }

        private static void LeftWalkTraverse<T>(this BinaryTree<T> tree, Node<T> currentNode, Stack<T> stack) where T : IComparable<T>
        {
            stack.Push(currentNode.Value);

            if (currentNode.Left == null) return;

            LeftWalkTraverse(tree, currentNode.Left, stack);
        }
        #endregion
    }
}
