using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructures.Tests
{
    public class QueueTests
    {
        [Test]
        public void Queue_Enqueue()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);
        }

        [Test]
        public void Queue_Dequeue()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var result = queue.Dequeue();

            Assert.AreEqual(1, result);
            Assert.AreEqual(2, queue.Count);
        }

        [Test]
        public void Stack_Peek()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var result = queue.Peek();

            Assert.AreEqual(1, result);
            Assert.AreEqual(3, queue.Count);
        }
    }
}
