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
            _tree = new BinarySearchTreeBase<int, string>();
            _root = _tree.Build(Constants.KeyValues);
        }

        [TestMethod]
        public void Build_ExpectsCorrectBinaryTree()
        {
            HasBinarySearchTreeProperties(_tree, _root, 10);
        }

        [TestMethod]
        public void Delete_Root_ExpectsReplacementByImmediateSuccessorKey42()
        {
            Assert.AreEqual(40, _root.Key);
            _root = _tree.Delete(_root, _root.Key);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            Assert.AreEqual(42, _root.Key);
        }

        [TestMethod]
        public void Delete_NodeWith2Children_ExpectsReplacementWithImmediateSuccessorKey50()
        {
            _root = _tree.Delete(_root, 50);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            Assert.AreEqual(80, _root.RightChild.Key);
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren()
        {
            _root = _tree.Delete(_root, 30);
            HasBinarySearchTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void Delete_NodeWithOneChildren_ExpectsReplacementByLeftChild()
        {
            _root = _tree.Delete(_root, 47);
            HasBinarySearchTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void Delete_MultipleNodesConsecutively_ExpectsCorrectBinarySearchTreeAfterEachStep()
        {
            _root = _tree.Delete(_root, 20);
            HasBinarySearchTreeProperties(_tree, _root, 9);

            _root = _tree.Delete(_root, 80);
            HasBinarySearchTreeProperties(_tree, _root, 8);

            _root = _tree.Delete(_root, 50);
            HasBinarySearchTreeProperties(_tree, _root, 7);
        }

        [TestMethod]
        public void Delete_NotExistingKey_ExpectsNoAlternationInTree()
        {
            _root = _tree.Delete(_root, 15);
            _root = _tree.Delete(_root, 800);
            _root = _tree.Delete(_root, 234);

            HasBinarySearchTreeProperties(_tree, _root, 10);
        }

        [TestMethod]
        public void DeleteMin_InEntireTree_ExpectsToDelete10AndHave20AsNewMin()
        {
            _root = _tree.DeleteMin(_root);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            var minNode = _tree.FindMin(_root);
            Assert.AreEqual(20, minNode.Key);
        }

        [TestMethod]
        public void DeleteMin_InRightSubtreeOfRoot_ExpectsToDelete42AndHave45AsMinAtTheEnd()
        {
            _root.RightChild = _tree.DeleteMin(_root.RightChild);
            HasBinarySearchTreeProperties(_tree, _root.RightChild, 4);
            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(45, minNode.Key);
        }

        [TestMethod]
        public void DeleteMax_InEntireTree_ExpectsToDelete80AndHave50AsNewMax()
        {
            _root = _tree.DeleteMax(_root);
            HasBinarySearchTreeProperties(_tree, _root, 9);
            var maxNode = _tree.FindMax(_root);
            Assert.AreEqual(50, maxNode.Key);
        }

        [TestMethod]
        public void DeleteMax_InLeftSubtreeOfRoot_ExpectsToDelete35AndHave30AsMinAtTheEnd()
        {
            _root.LeftChild = _tree.DeleteMax(_root.LeftChild);
            HasBinarySearchTreeProperties(_tree, _root.LeftChild, 3);
            var maxNode = _tree.FindMax(_root.LeftChild);
            Assert.AreEqual(30, maxNode.Key);
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

