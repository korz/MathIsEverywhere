using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructures.Tests.BinaryTree
{
    public class Contains
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
        public void Does_Contain()
        {
            var result = this._tree.Contains(4);

            Assert.IsTrue(result);
        }

        [Test]
        public void Does_Not_Contain()
        {
            var result = this._tree.Contains(8);

            Assert.IsFalse(result);
        }

        [Test]
        public void Contains_More_Than_One()
        {
            this._tree.Add(4);

            var result = this._tree.Contains(4);
            
            Assert.IsTrue(result);
        }
    }
}
