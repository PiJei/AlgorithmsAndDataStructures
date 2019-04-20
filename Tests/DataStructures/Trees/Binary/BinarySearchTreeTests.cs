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

        /// <summary>
        /// Is a binary search tree (aka. BST). 
        /// To visualize this tree built as in <see cref="Init()"/> method, please <see cref="images\bst.png"/> in current directory. 
        /// </summary>
        private BinarySearchTreeBase<int, string> _tree;

        [TestInitialize]
        public void Init()
        {
            var nodes = new List<BinarySearchTreeNode<int, string>>
            {
                new BinarySearchTreeNode<int, string>(40, "E"),
                new BinarySearchTreeNode<int, string>(50, "C"),
                new BinarySearchTreeNode<int, string>(47, "A"),
                new BinarySearchTreeNode<int, string>(45, "G"),
                new BinarySearchTreeNode<int, string>(20, "D"),
                new BinarySearchTreeNode<int, string>(35, "F"),
                new BinarySearchTreeNode<int, string>(30, "B"),
                new BinarySearchTreeNode<int, string>(10, "H"),
                new BinarySearchTreeNode<int, string>(80, "I"),
                new BinarySearchTreeNode<int, string>(42, "J")
            };

            _tree = new BinarySearchTreeBase<int, string>();
            _root = _tree.Build(nodes);
        }

        [TestMethod]
        public void Build()
        {
            HasBinarySearchTreeProperties(_tree, _root, 10);
        }

        [TestMethod]
        public void Delete_Root()
        {
            Assert.AreEqual(40, _root.Key);
            _root = _tree.Delete(_root, _root.Key);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            Assert.AreEqual(42, _root.Key);
        }

        [TestMethod]
        public void Delete_NodeWith2Children()
        {
            _root = _tree.Delete(_root, 50);
            HasBinarySearchTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren()
        {
            _root = _tree.Delete(_root, 30);
            HasBinarySearchTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void Delete_NodeWithOneChildren()
        {
            _root = _tree.Delete(_root, 47);
            HasBinarySearchTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void Delete_MultipleNodes()
        {
            _root = _tree.Delete(_root, 20);
            HasBinarySearchTreeProperties(_tree, _root, 9);

            _root = _tree.Delete(_root, 80);
            HasBinarySearchTreeProperties(_tree, _root, 8);

            _root = _tree.Delete(_root, 50);
            HasBinarySearchTreeProperties(_tree, _root, 7);
        }

        [TestMethod]
        public void Delete_NotExistingKey()
        {
            _root = _tree.Delete(_root, 15);
            _root = _tree.Delete(_root, 800);
            _root = _tree.Delete(_root, 234);

            HasBinarySearchTreeProperties(_tree, _root, 10);
        }

        [TestMethod]
        public void DeleteMin_1()
        {
            _root = _tree.DeleteMin(_root);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            var minNode = _tree.FindMin(_root);
            Assert.AreEqual(20, minNode.Key);
        }

        [TestMethod]
        public void DeleteMin_2()
        {
            _root.RightChild = _tree.DeleteMin(_root.RightChild);
            HasBinarySearchTreeProperties(_tree, _root.RightChild, 4);
            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(45, minNode.Key);
        }

        [TestMethod]
        public void DeleteMax_1()
        {
            _root = _tree.DeleteMax(_root);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            var minNode = _tree.FindMax(_root);
            Assert.AreEqual(50, minNode.Key);
        }

        [TestMethod]
        public void DeleteMax_2()
        {
            _root.LeftChild = _tree.DeleteMax(_root.LeftChild);
            HasBinarySearchTreeProperties(_tree, _root.LeftChild, 3);
            var minNode = _tree.FindMax(_root.LeftChild);
            Assert.AreEqual(30, minNode.Key);
        }

        public void HasBinarySearchTreeProperties(BinarySearchTreeBase<int, string> tree, BinarySearchTreeNode<int, string> root, int expectedTotalKeyCount)
        {
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(root));

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            tree.InOrderTraversal(root, inOrderTraversal);
            Assert.AreEqual(expectedTotalKeyCount, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }
    }
}

