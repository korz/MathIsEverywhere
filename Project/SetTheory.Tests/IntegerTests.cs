using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SetTheory.Tests
{
    public class IntegerTests
    {
        [Test]
        public void Subset()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 5, 3, 4, 3, 6 };

            var result = !a.Except(b).Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void SetEquality()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 3 };

            var result = a.SequenceEqual(b);

            Assert.IsTrue(result);
        }

        [Test]
        public void Union()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 3, 4, 5, 6 };

            var results = a.Union(b).ToList();

            Assert.AreEqual(6, results.Count());
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(3, results[2]);
            Assert.AreEqual(4, results[3]);
            Assert.AreEqual(5, results[4]);
            Assert.AreEqual(6, results[5]);
        }

        [Test]
        public void Intersection()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 3, 4, 5, 6 };

            var results = a.Intersect(b).ToList();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(3, results[2]);
        }

        [Test]
        public void Difference()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 3, 4, 5, 6 };

            var results = b.Except(a).ToList();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual(4, results[0]);
            Assert.AreEqual(5, results[1]);
            Assert.AreEqual(6, results[2]);
        }
    }
}
