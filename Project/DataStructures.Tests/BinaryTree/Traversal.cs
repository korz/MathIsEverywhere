using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DataStructures.Tests.BinaryTree
{
    public class Traversal
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
        public void LeftWalkTraversal()
        {
            var results = this._tree.LeftWalkTraverse().ToList();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(4, results[2]);
        }

        [Test]
        public void PreOrderTraversal()
        {
            var results = this._tree.PreOrderTraverse().ToList();

            Assert.AreEqual(7, results.Count());
            Assert.AreEqual(4, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(1, results[2]);
            Assert.AreEqual(3, results[3]);
            Assert.AreEqual(6, results[4]);
            Assert.AreEqual(5, results[5]);
            Assert.AreEqual(7, results[6]);
        }

        [Test]
        public void PreOrderTraversal_With_Action()
        {
            var list = new List<int>();
            Action<int> adder = x => AddOne(x, list);

            this._tree.PreOrderTraverse(adder);

            Assert.AreEqual(7, list.Count());
            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(4, list[3]);
            Assert.AreEqual(7, list[4]);
            Assert.AreEqual(6, list[5]);
            Assert.AreEqual(8, list[6]);
        }

        private void AddOne(int value, IList<int> list)
        {
            value = value + 1;

            list.Add(value);
        }
    }
}
