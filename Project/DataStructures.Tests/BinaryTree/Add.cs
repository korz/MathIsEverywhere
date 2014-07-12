using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructures.Tests.BinaryTree
{
    public class Add
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
        public void Simple_Create()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            var tree = new BinaryTree<int>();

            tree.Add(list[3]);
            tree.Add(list[1]);
            tree.Add(list[0]);
            tree.Add(list[2]);

            tree.Add(list[5]);
            tree.Add(list[4]);
            tree.Add(list[6]);

            Assert.AreEqual(4, tree.Root.Value);

            Assert.AreEqual(2, tree.Root.Left.Value);
            Assert.AreEqual(1, tree.Root.Left.Left.Value);
            Assert.AreEqual(3, tree.Root.Left.Right.Value);
            Assert.AreEqual(null, tree.Root.Left.Left.Left);
            Assert.AreEqual(null, tree.Root.Left.Left.Right);
            Assert.AreEqual(null, tree.Root.Left.Right.Left);
            Assert.AreEqual(null, tree.Root.Left.Right.Right);
            Assert.AreEqual(6, tree.Root.Right.Value);
            Assert.AreEqual(5, tree.Root.Right.Left.Value);
            Assert.AreEqual(7, tree.Root.Right.Right.Value);
            Assert.AreEqual(null, tree.Root.Right.Left.Left);
            Assert.AreEqual(null, tree.Root.Right.Left.Right);
            Assert.AreEqual(null, tree.Root.Right.Right.Left);
            Assert.AreEqual(null, tree.Root.Right.Right.Right);
        }

        [Test]
        public void Add_Off_1()
        {
            this._tree.AddTo(this._tree.Root.Left.Left, 0);

            Assert.AreEqual(4, this._tree.Root.Value);

            Assert.AreEqual(2, this._tree.Root.Left.Value);
            Assert.AreEqual(1, this._tree.Root.Left.Left.Value);
            Assert.AreEqual(3, this._tree.Root.Left.Right.Value);
            Assert.AreEqual(0, this._tree.Root.Left.Left.Left.Value);
            Assert.AreEqual(null, this._tree.Root.Left.Left.Right);
            Assert.AreEqual(null, this._tree.Root.Left.Right.Left);
            Assert.AreEqual(null, this._tree.Root.Left.Right.Right);
            Assert.AreEqual(6, this._tree.Root.Right.Value);
            Assert.AreEqual(5, this._tree.Root.Right.Left.Value);
            Assert.AreEqual(7, this._tree.Root.Right.Right.Value);
            Assert.AreEqual(null, this._tree.Root.Right.Left.Left);
            Assert.AreEqual(null, this._tree.Root.Right.Left.Right);
            Assert.AreEqual(null, this._tree.Root.Right.Right.Left);
            Assert.AreEqual(null, this._tree.Root.Right.Right.Right);
        }

        [Test]
        public void Add_Duplicate()
        {
            this._tree.Add(4);

            Assert.AreEqual(4, this._tree.Root.Value);

            Assert.AreEqual(2, this._tree.Root.Left.Value);
            Assert.AreEqual(1, this._tree.Root.Left.Left.Value);
            Assert.AreEqual(3, this._tree.Root.Left.Right.Value);
            Assert.AreEqual(null, this._tree.Root.Left.Left.Left);
            Assert.AreEqual(null, this._tree.Root.Left.Left.Right);
            Assert.AreEqual(null, this._tree.Root.Left.Right.Left);
            Assert.AreEqual(null, this._tree.Root.Left.Right.Right);

            Assert.AreEqual(6, this._tree.Root.Right.Value);
            Assert.AreEqual(5, this._tree.Root.Right.Left.Value);
            Assert.AreEqual(7, this._tree.Root.Right.Right.Value);
            Assert.AreEqual(4, this._tree.Root.Right.Left.Left.Value);
            Assert.AreEqual(null, this._tree.Root.Right.Left.Right);
            Assert.AreEqual(null, this._tree.Root.Right.Right.Left);
            Assert.AreEqual(null, this._tree.Root.Right.Right.Right);
        }
    }
}
