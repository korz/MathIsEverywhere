using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructures.Tests
{
    public class StackTests
    {
        [Test]
        public void Stack_Push()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            Assert.AreEqual(3, stack.Count);
        }

        [Test]
        public void Stack_Pop()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var result = stack.Pop();

            Assert.AreEqual(3, result);
            Assert.AreEqual(2, stack.Count);
        }

        [Test]
        public void Stack_Peek()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var result = stack.Peek();

            Assert.AreEqual(3, result);
            Assert.AreEqual(3, stack.Count);
        }
    }
}
