using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DataStructures.Tests.BinaryTree
{
    public class LeftWalkTraversal
    {
        private BinaryTree<int> _tree;

        [SetUp]
        public void Setup()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            this._tree = new BinaryTree<int>();

            this._tree.Add(list[3]);
            this._tree.Add(list[1]);
            this._tree.Add(list[0]);
            this._tree.Add(list[2]);
            this._tree.Add(list[5]);
            this._tree.Add(list[4]);
            this._tree.Add(list[6]);
        }

        [TearDown]
        public void TearDown()
        {
            this._tree = null;
        }

        [Test]
        public void LeftWalkTraversal_Test()
        {
            var results = this._tree.LeftWalkTraverse().ToList();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(4, results[2]);
        }
    }
}
