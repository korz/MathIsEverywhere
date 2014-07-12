using System.Collections.Generic;

namespace DataStructures.TraversableQueue
{
    public class TraversableQueue<T>
    {
        private readonly LinkedList<T> _queue;

        public int Count { get { return this._queue.Count; } }

        public TraversableQueue()
        {
            this._queue = new LinkedList<T>();
        }

        public TraversableQueue(Queue<T> queue)
        {
            this._queue = queue.ToLinkedList();
        }

        public void Clear()
        {
            this._queue.Clear();
        }

        public bool Contains(T value)
        {
            return this._queue.Contains(value);
        }

        public void CopyTo(T[] array)
        {
            this._queue.CopyTo(array, 0);
        }

        public void Enqueue(T item)
        {
            this._queue.AddLast(item);
        }

        public T Dequeue()
        {
            var node = this.DequeueNode();

            return node == null ? default(T) : node.Value;
        }

        public LinkedListNode<T> DequeueNode()
        {
            return this._queue.CutFirstNode();
        }

        public T Peek()
        {
            return this._queue.First == null ? default(T) : this._queue.First.Value;
        }

        public LinkedListNode<T> PeekNode()
        {
            return this._queue.First;
        }

        public LinkedListNode<T> NodeAt(int index)
        {
            if (index < 0) return null;
            if (index == 0) return this._queue.First;
            if (index == this._queue.Count - 1) return this._queue.Last;

            var counter = 0;
            var currentNode = this._queue.First;
            if (currentNode == null) return null;

            while (counter < index)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            return currentNode;
        }

        public T ElementAt(int index)
        {
            var node = this.NodeAt(index);

            return node == null ? default(T) : node.Value;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            this.CopyTo(array);

            return array;
        }

        public Queue<T> ToQueue()
        {
            return new Queue<T>(this._queue);
        }
    }
}
