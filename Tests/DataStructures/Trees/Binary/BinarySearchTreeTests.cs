/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using CSFundamentals.DataStructures.Trees.Binary;
using CSFundamentalsTests.DataStructures.Trees.Binary.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.Trees.Binary
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private BinarySearchTreeNode<int, string> _root;
        private BinarySearchTreeBase<int, string> _tree;

        [TestInitialize]
        public void Init()
        {
            var nodes = new List<BinarySearchTreeNode<int, string>>
            {
                new BinarySearchTreeNode<int, string>(40,"A"),
                new BinarySearchTreeNode<int, string>(20,"B"),
                new BinarySearchTreeNode<int, string>(70,"C"),
                new BinarySearchTreeNode<int, string>(50,"D"),
                new BinarySearchTreeNode<int, string>(80,"E"),
                new BinarySearchTreeNode<int, string>(30,"F"),
                new BinarySearchTreeNode<int, string>(60,"G")
            };

            _tree = new BinarySearchTreeBase<int, string>();
            _root = _tree.Build(nodes);
        }

        [TestMethod]
        public void Build()
        {
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));
        }

        [TestMethod]
        public void Delete_Root()
        {
            _root = _tree.Delete(_root, _root.Key);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void Delete_NodeWith2Children()
        {
            _root = _tree.Delete(_root, 70);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren()
        {
            _root = _tree.Delete(_root, 30);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void Delete_NodeWithOneChildren()
        {
            _root = _tree.Delete(_root, 20);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void Delete_MultipleNodes()
        {
            _root = _tree.Delete(_root, 20);
            _root = _tree.Delete(_root, 40);
            _root = _tree.Delete(_root, 50);

            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(4, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void Delete_NotExistingKey()
        {
            _root = _tree.Delete(_root, 15);
            _root = _tree.Delete(_root, 800);
            _root = _tree.Delete(_root, 234);

            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(7, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void DeleteMin_1()
        {
            _root = _tree.DeleteMin(_root);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root);
            Assert.AreEqual(30, minNode.Key);
        }

        [TestMethod]
        public void DeleteMin_2()
        {
            _root.RightChild = _tree.DeleteMin(_root.RightChild);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root.RightChild));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root.RightChild, inOrderTraversal);
            Assert.AreEqual(3, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(60, minNode.Key);
        }

        [TestMethod]
        public void DeleteMax_1()
        {
            _root = _tree.DeleteMax(_root);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMax(_root);
            Assert.AreEqual(70, minNode.Key);
        }

        [TestMethod]
        public void DeleteMax_2()
        {
            _root.RightChild = _tree.DeleteMax(_root.LeftChild);
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root.LeftChild));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            _tree.InOrderTraversal(_root.LeftChild, inOrderTraversal);
            Assert.AreEqual(1, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(20, minNode.Key);
        }
    }
}

