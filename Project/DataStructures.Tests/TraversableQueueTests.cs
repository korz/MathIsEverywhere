using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataStructures.TraversableQueue;

namespace DataStructures.Tests
{
    public class TraversableQueueTests
    {
        #region Setup / Tear Down
        private TraversableQueue<int> _queue;

        [SetUp]
        public void Setup()
        {
            this._queue = new TraversableQueue<int>();
        }

        [TearDown]
        public void TearDown()
        {
            this._queue = null;
        }
        #endregion

        [Test]
        public void Enqueue_Single()
        {
            Assert.AreEqual(0, this._queue.Count);

            this._queue.Enqueue(1);

            Assert.AreEqual(1, this._queue.Peek());
            Assert.AreEqual(1, this._queue.Count);
        }

        [Test]
        public void Enqueue_Multiple()
        {
            Assert.AreEqual(0, this._queue.Count);

            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            Assert.AreEqual(1, this._queue.Peek());
            Assert.AreEqual(2, this._queue.PeekNode().Next.Value);
            Assert.AreEqual(3, this._queue.PeekNode().Next.Next.Value);
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void Dequeue()
        {
            Assert.AreEqual(0, this._queue.Count);

            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            this._queue.Dequeue();
            this._queue.Dequeue();

            Assert.AreEqual(3, this._queue.Peek());
            Assert.IsNull(this._queue.PeekNode().Next);
            Assert.IsNull(this._queue.PeekNode().Previous);
            Assert.AreEqual(1, this._queue.Count);
        }

        [Test]
        public void DequeueNode()
        {
            Assert.AreEqual(0, this._queue.Count);

            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var node1 = this._queue.DequeueNode();
            var node2 = this._queue.DequeueNode();

            Assert.AreEqual(1, node1.Value);
            Assert.IsNull(node1.Next);
            Assert.IsNull(node1.Previous);

            Assert.AreEqual(2, node2.Value);
            Assert.IsNull(node2.Next);
            Assert.IsNull(node2.Previous);

            Assert.IsNull(this._queue.PeekNode().Next);
            Assert.IsNull(this._queue.PeekNode().Previous);
            Assert.AreEqual(3, this._queue.Peek());
            Assert.AreEqual(1, this._queue.Count);
        }

        [Test]
        public void Peek()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            Assert.AreEqual(1, this._queue.Peek());
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void PeekNode()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            Assert.AreEqual(1, this._queue.PeekNode().Value);
            Assert.IsNull(this._queue.PeekNode().Previous);
            Assert.AreEqual(2, this._queue.PeekNode().Next.Value);
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void Contains()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            Assert.AreEqual(true, this._queue.Contains(1));
            Assert.AreEqual(true, this._queue.Contains(2));
            Assert.AreEqual(true, this._queue.Contains(3));
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void Does_Not_Contain()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);

            Assert.AreEqual(true, this._queue.Contains(1));
            Assert.AreEqual(true, this._queue.Contains(2));
            Assert.AreEqual(false, this._queue.Contains(3));
            Assert.AreEqual(2, this._queue.Count);
        }

        [Test]
        public void Clear()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);

            this._queue.Clear();

            Assert.AreEqual(0, this._queue.Peek());
            Assert.AreEqual(null, this._queue.PeekNode());
            Assert.AreEqual(0, this._queue.Count);
        }

        [Test]
        public void CopyTo()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var array = new int[3];

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(0, array[1]);
            Assert.AreEqual(0, array[2]);
            Assert.AreEqual(3, array.Count());

            this._queue.CopyTo(array);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(3, array.Count());
        }

        [Test]
        public void ToArray()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var array = this._queue.ToArray();

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(3, array.Count());
        }

        [Test]
        public void ToQueue()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var queue = this._queue.ToQueue();

            Assert.AreEqual(3, queue.Count());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Count());
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void ToList()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var list = this._queue.ToList();

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void Traverse()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var array = this._queue.Traverse().ToList();

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(3, array.Count());
        }

        [Test]
        public void ToLinkedList()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            var linkedList = queue.ToLinkedList();

            //Prove Idempotency of the Queue (doesn't destroy the queue)
            Assert.AreEqual(5, queue.Count);

            //Ensure linked list in in the same order
            Assert.AreEqual(5, linkedList.Count);
            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(2, linkedList.First.Next.Value);
            Assert.AreEqual(3, linkedList.First.Next.Next.Value);
            Assert.AreEqual(4, linkedList.First.Next.Next.Next.Value);
            Assert.AreEqual(5, linkedList.First.Next.Next.Next.Next.Value);
        }

        [Test]
        public void NodeAt()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var node1 = this._queue.NodeAt(-1);
            Assert.IsNull(node1);

            var node2 = this._queue.NodeAt(0);
            Assert.AreEqual(1, node2.Value);

            var node3 = this._queue.NodeAt(1);
            Assert.AreEqual(2, node3.Value);

            var node4 = this._queue.NodeAt(2);
            Assert.AreEqual(3, node4.Value);

            //Make sure we didn't accidently dequeue
            Assert.AreEqual(3, this._queue.Count);
        }

        [Test]
        public void NodeAt_Longer_Queue()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);
            this._queue.Enqueue(4);
            this._queue.Enqueue(5);

            var node1 = this._queue.NodeAt(-1);
            Assert.IsNull(node1);

            var node2 = this._queue.NodeAt(0);
            Assert.AreEqual(1, node2.Value);

            var node3 = this._queue.NodeAt(1);
            Assert.AreEqual(2, node3.Value);

            var node4 = this._queue.NodeAt(2);
            Assert.AreEqual(3, node4.Value);

            var node5 = this._queue.NodeAt(3);
            Assert.AreEqual(4, node5.Value);

            var node6 = this._queue.NodeAt(4);
            Assert.AreEqual(5, node6.Value);

            //Make sure we didn't accidently dequeue
            Assert.AreEqual(5, this._queue.Count);
        }

        [Test]
        public void ElementAt()
        {
            this._queue.Enqueue(1);
            this._queue.Enqueue(2);
            this._queue.Enqueue(3);

            var element1 = this._queue.ElementAt(-1);
            Assert.AreEqual(default(int), element1);

            var element2 = this._queue.ElementAt(0);
            Assert.AreEqual(1, element2);

            var element3 = this._queue.ElementAt(1);
            Assert.AreEqual(2, element3);

            var element4 = this._queue.ElementAt(2);
            Assert.AreEqual(3, element4);

            //Make sure we didn't accidently dequeue
            Assert.AreEqual(3, this._queue.Count);
        }
    }
}
