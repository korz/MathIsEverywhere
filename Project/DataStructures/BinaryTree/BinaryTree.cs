using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Node<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public TNode Value { get; set; }
        public Node<TNode> Left { get; set; }
        public Node<TNode> Right { get; set; }

        public Node(TNode value)
        {
            this.Value = value;
        }

        public int CompareTo(TNode other)
        {
            return this.Value.CompareTo(other);
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; internal set; }
        public int Count { get; internal set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrderTraverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }
    }
}
