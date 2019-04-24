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

using System;
using System.Collections.Generic;
using CSFundamentals.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// TODO  Tests make them more exact to check the content of the nodes after rotation so that any change in implementation can expose mistakes
namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    /// <summary>
    /// Tests BTree implementation by a 2-3 B-Tree, where minimum number of children for a non-root tree is 2, and maximum number of children for any node is 3. 
    /// </summary>
    [TestClass]
    public class _2_3_BTreeTests
    {
        /// <summary>
        /// Is a B tree. 
        /// To visualize this tree built as in <see cref="Init()"/> method, please <see cref="Images\2-3-BTree.png"/> in current directory. 
        /// </summary>
        private BTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new BTree<int, string>(3);
            var keyValues = new Dictionary<int, string>
            {
                [50] = "A",
                [10] = "B",
                [100] = "C",
                [200] = "D",
                [20] = "E",
                [300] = "F",
                [30] = "G",
                [500] = "H",
                [250] = "I",
                [400] = "J",
                [270] = "K",
                [600] = "L",
                [150] = "M",
                [80] = "N",
                [60] = "O",
                [90] = "P"
            };
            _tree.Build(keyValues);
        }

        [TestMethod]
        public void Build_ExpectsACorrectBTree()
        {
            BTreeTestsUtils.HasBTreeProperties(_tree, 16, 16, 15);
        }

        [TestMethod]
        public void GetMaxCapacity_ForATreeWithOneToFiveLevels_ExpectsNumbersAsIndicatedInAsserts()
        {
            Assert.AreEqual(2, _tree.GetMaxCapacity(levelCount: 1)); /* One level means the tree has only one node: the root. */
            Assert.AreEqual(8, _tree.GetMaxCapacity(levelCount: 2));
            Assert.AreEqual(26, _tree.GetMaxCapacity(levelCount: 3));
            Assert.AreEqual(80, _tree.GetMaxCapacity(levelCount: 4));
            Assert.AreEqual(242, _tree.GetMaxCapacity(levelCount: 5));
        }

        [TestMethod]
        public void FindLeafToInsertKey_NewKeySmallerThanAllKeysInTree_ExpectsTheSparseLeafNodeContainingSmallestKey()
        {
            var leaf = _tree.FindLeafToInsertKey(_tree.Root, 5);
            Assert.AreEqual(1, leaf.KeyCount);
            Assert.IsTrue(leaf.IsLeaf());
            Assert.AreEqual(10, leaf.GetKey(0));
        }

        [TestMethod]
        public void FindLeafToInsertKey_NewKeyBiggerThanAllKeysInTree_ExpectsTheSparseLeafNodeContainingBiggestKey()
        {
            var leaf = _tree.FindLeafToInsertKey(_tree.Root, 800);
            Assert.AreEqual(1, leaf.KeyCount);
            Assert.IsTrue(leaf.IsLeaf());
            Assert.AreEqual(600, leaf.GetKey(0));
        }

        [TestMethod]
        public void FindLeafToInsertKey_NewKey_ExpectsSuccess()
        {
            var leaf = _tree.FindLeafToInsertKey(_tree.Root, 75);
            Assert.AreEqual(1, leaf.KeyCount);
            Assert.IsTrue(leaf.IsLeaf());
            Assert.AreEqual(60, leaf.GetKey(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindLeafToInsertKey_DuplicateKey_ThrowsException()
        {
            _tree.FindLeafToInsertKey(_tree.Root, 50);
        }

        /// <summary>
        /// For a step by step transition of this 2-3 BTree while inserting these keys, please <see cref="images\2-3-BTree-insert-stepBystep.png"/>.
        /// </summary>
        [TestMethod]
        public void Insert_SeveralKeys_ExpectsTreeToIncreaseInLevelsAfewTimes()
        {
            var tree = new BTree<int, string>(3);
            BTreeTestsUtils.HasBTreeProperties(tree, 0, 0, 0);

            tree.Insert(new KeyValuePair<int, string>(50, "A"));
            BTreeTestsUtils.HasBTreeProperties(tree, 1, 1, 1);

            tree.Insert(new KeyValuePair<int, string>(10, "B"));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);

            tree.Insert(new KeyValuePair<int, string>(100, "C"));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);

            tree.Insert(new KeyValuePair<int, string>(200, "D"));
            BTreeTestsUtils.HasBTreeProperties(tree, 4, 4, 3);

            tree.Insert(new KeyValuePair<int, string>(20, "E"));
            BTreeTestsUtils.HasBTreeProperties(tree, 5, 5, 3);

            tree.Insert(new KeyValuePair<int, string>(300, "F"));
            BTreeTestsUtils.HasBTreeProperties(tree, 6, 6, 4);

            tree.Insert(new KeyValuePair<int, string>(30, "G"));
            BTreeTestsUtils.HasBTreeProperties(tree, 7, 7, 7);

            tree.Insert(new KeyValuePair<int, string>(500, "H"));
            BTreeTestsUtils.HasBTreeProperties(tree, 8, 8, 7);

            tree.Insert(new KeyValuePair<int, string>(250, "I"));
            BTreeTestsUtils.HasBTreeProperties(tree, 9, 9, 8);

            tree.Insert(new KeyValuePair<int, string>(400, "J"));
            BTreeTestsUtils.HasBTreeProperties(tree, 10, 10, 8);

            tree.Insert(new KeyValuePair<int, string>(270, "K"));
            BTreeTestsUtils.HasBTreeProperties(tree, 11, 11, 8);

            tree.Insert(new KeyValuePair<int, string>(600, "L"));
            BTreeTestsUtils.HasBTreeProperties(tree, 12, 12, 10);

            tree.Insert(new KeyValuePair<int, string>(150, "M"));
            BTreeTestsUtils.HasBTreeProperties(tree, 13, 13, 10);

            tree.Insert(new KeyValuePair<int, string>(80, "N"));
            BTreeTestsUtils.HasBTreeProperties(tree, 14, 14, 11);

            tree.Insert(new KeyValuePair<int, string>(60, "O"));
            BTreeTestsUtils.HasBTreeProperties(tree, 15, 15, 11);

            tree.Insert(new KeyValuePair<int, string>(90, "P"));
            BTreeTestsUtils.HasBTreeProperties(tree, 16, 16, 15);

            Assert.AreEqual(1, tree.Root.KeyCount);
            Assert.AreEqual(100, tree.Root.GetKeyValue(0).Key);
            Assert.AreEqual("C", tree.Root.GetKeyValue(0).Value, ignoreCase: true);
        }

        [TestMethod]
        public void InOrderTraversal_StartingFromRoot_ExpectsAscendingOrder()
        {
            var keyValues = new List<KeyValuePair<int, string>>();
            _tree.InOrderTraversal(_tree.Root, keyValues);
            Assert.AreEqual(16, keyValues.Count);
            for (int i = 0; i < keyValues.Count - 1; i++)
            {
                Assert.IsTrue(keyValues[i].Key < keyValues[i + 1].Key);
            }
        }

        [TestMethod]
        public void Search_ForAllExistingKeysInTree_ExpectsSuccess()
        {
            var node1 = _tree.Search(_tree.Root, 100);
            Assert.IsTrue(node1.KeyCount == 1);

            var node2 = _tree.Search(_tree.Root, 300);
            Assert.IsTrue(node2.KeyCount == 1);

            var node3 = _tree.Search(_tree.Root, 500);
            Assert.IsTrue(node3.KeyCount == 1);

            var node4 = _tree.Search(_tree.Root, 200);
            Assert.IsTrue(node4.KeyCount == 1);

            var node5 = _tree.Search(_tree.Root, 250);
            Assert.IsTrue(node5.KeyCount == 2);

            var node6 = _tree.Search(_tree.Root, 270);
            Assert.IsTrue(node6.KeyCount == 2);

            var node7 = _tree.Search(_tree.Root, 400);
            Assert.IsTrue(node7.KeyCount == 1);

            var node8 = _tree.Search(_tree.Root, 600);
            Assert.IsTrue(node8.KeyCount == 1);

            var node9 = _tree.Search(_tree.Root, 50);
            Assert.IsTrue(node9.KeyCount == 1);

            var node10 = _tree.Search(_tree.Root, 20);
            Assert.IsTrue(node10.KeyCount == 1);

            var node11 = _tree.Search(_tree.Root, 90);
            Assert.IsTrue(node11.KeyCount == 1);

            var node12 = _tree.Search(_tree.Root, 60);
            Assert.IsTrue(node12.KeyCount == 1);

            var node13 = _tree.Search(_tree.Root, 80);
            Assert.IsTrue(node13.KeyCount == 1);

            var node14 = _tree.Search(_tree.Root, 10);
            Assert.IsTrue(node14.KeyCount == 1);

            var node15 = _tree.Search(_tree.Root, 30);
            Assert.IsTrue(node15.KeyCount == 1);

            var node16 = _tree.Search(_tree.Root, 150);
            Assert.IsTrue(node16.KeyCount == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Search_NotExistingKey_ThrowsException()
        {
            var node1 = _tree.Search(_tree.Root, 5);
        }

        [TestMethod]
        public void Delete_Root_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(100));
            Assert.AreEqual(2, _tree.Root.KeyCount);
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyOfLeftChildOfRoot_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(50));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyOfRightChildOfRoot_ExpectsToReduceBy1Key()
        {
            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 15);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInParentNodeOfLeftMostLeavesOnLeftSubtree_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInParentNodeOfRightMostLeavesOnLeftSubtree_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInParentNodeOfLeftMostLeavesOnRightSubtree_ExpectsToReduceBy1Key()
        {
            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 15);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInParentNodeOfRightMostLeavesOnRightSubtree_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInTreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_ThirdSmallestKeyInTreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_SmallestKeyInRightSubtreeOfLeftSubtreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_BiggestKeyInLeftSubtreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_SmallestKeyInRightSubtreeLeafNode_ExpectsToReduceBy1Key()
        {
            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 15);
        }

        [TestMethod]
        public void Delete_SmallestKeyInAFullLeaf_ExpectsToReduceBy1Key()
        {
            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 15);
        }

        [TestMethod]
        public void Delete_BiggestKeyInAFullLeaf_ExpectsToReduceBy1Key()
        {
            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 15);
        }

        [TestMethod]
        public void Delete_ThirdBiggestKeyInTreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        [TestMethod]
        public void Delete_BiggestKeyInTreeLeafNode_ExpectsToReduceBy4NodesAnd1Key()
        {
            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);
        }

        /// <summary>
        /// For a step by step transition of this 2-3 BTree while deleting these keys, please <see cref="images\2-3-BTree-delete-stepBystep.png"/>.
        /// </summary>
        [TestMethod]
        public void Delete_AllNodesInRandomOrder1_ExpectsProperBtreeAfterEachDelete()
        {
            Assert.IsTrue(_tree.Delete(100));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);

            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBTreeProperties(_tree, 14, 14, 10);

            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBTreeProperties(_tree, 13, 13, 10);

            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBTreeProperties(_tree, 12, 12, 8);

            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBTreeProperties(_tree, 11, 11, 8);

            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBTreeProperties(_tree, 10, 10, 8);

            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(_tree, 9, 9, 8);

            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBTreeProperties(_tree, 8, 8, 7);

            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBTreeProperties(_tree, 7, 7, 4);

            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBTreeProperties(_tree, 6, 6, 4);

            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBTreeProperties(_tree, 5, 5, 4);

            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBTreeProperties(_tree, 4, 4, 3);

            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBTreeProperties(_tree, 3, 3, 3);

            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBTreeProperties(_tree, 2, 2, 1);

            Assert.IsTrue(_tree.Delete(50));
            BTreeTestsUtils.HasBTreeProperties(_tree, 1, 1, 1);

            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBTreeProperties(_tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_AllNodesInRandomOrder2_ExpectsProperBtreeAfterEachDelete()
        {
            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBTreeProperties(_tree, 15, 15, 11);

            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBTreeProperties(_tree, 14, 14, 9);

            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBTreeProperties(_tree, 13, 13, 9);

            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBTreeProperties(_tree, 12, 12, 9);

            Assert.IsTrue(_tree.Delete(100));
            BTreeTestsUtils.HasBTreeProperties(_tree, 11, 11, 8);

            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBTreeProperties(_tree, 10, 10, 8);

            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBTreeProperties(_tree, 9, 9, 8);

            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(_tree, 8, 8, 7);

            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBTreeProperties(_tree, 7, 7, 4);

            Assert.IsTrue(_tree.Delete(50));
            BTreeTestsUtils.HasBTreeProperties(_tree, 6, 6, 4);

            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBTreeProperties(_tree, 5, 5, 4);

            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBTreeProperties(_tree, 4, 4, 3);

            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBTreeProperties(_tree, 3, 3, 3);

            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBTreeProperties(_tree, 2, 2, 1);

            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBTreeProperties(_tree, 1, 1, 1);

            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBTreeProperties(_tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInTree_ExpectsNoNodeAndNoKeyAfter()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            BTreeTestsUtils.HasBTreeProperties(tree, 1, 1, 1);

            /* Deleting the only key in the only node of the tree. */
            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_BiggestKeyInTheOnlyNodeOfTree_ExpectsToReduceBy1Key()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(100, "B"));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);

            /* Deleting 1 out of 2 keys in the only node of the tree. */
            Assert.IsTrue(tree.Delete(100));
            BTreeTestsUtils.HasBTreeProperties(tree, 1, 1, 1);
        }

        [TestMethod]
        public void Delete_NonExistingKey_ExpectsFailure()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(100, "B"));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);

            /* Deleting a non-existing key. */
            Assert.IsFalse(tree.Delete(50));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInInternalNode_ExpectsToTriggerJoinAndReduceBy2NodesAnd1Key()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);

            Assert.IsTrue(tree.Delete(20));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNode_ExpectsToTriggerJoinByRightSiblingAndReduceBy2NodesAnd1Key()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);

            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNode_ExpectsToTriggerJoinByLeftSiblingAndReduceBy2NodesAnd1Key()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);

            Assert.IsTrue(tree.Delete(30));
            BTreeTestsUtils.HasBTreeProperties(tree, 2, 2, 1);
        }

        [TestMethod]
        public void Delete_KeyInFullLeaf_ExpectsToReduceBy1Key()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            BTreeTestsUtils.HasBTreeProperties(tree, 4, 4, 3);

            Assert.IsTrue(tree.Delete(30));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNodeWithMinOneFullSibling_ExpectsToTriggerLeftRotate()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            BTreeTestsUtils.HasBTreeProperties(tree, 4, 4, 3);

            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);
        }

        [TestMethod]
        public void Delete_DeleteTheOnlyKeyInInternalNode_ExpectsToTriggerLeafDeleteAndLeftRotate()
        {
            var tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            BTreeTestsUtils.HasBTreeProperties(tree, 4, 4, 3);

            Assert.IsTrue(tree.Delete(20));
            BTreeTestsUtils.HasBTreeProperties(tree, 3, 3, 3);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafWithFullParentAndMinOneFullSibling_ExpectsLeftRotateAndToReduceBy1Key()
        {
            var root = new BTreeNode<int, string>(3);
            root.InsertKeyValue(new KeyValuePair<int, string>(90, "A"));
            root.InsertKeyValue(new KeyValuePair<int, string>(200, "B"));

            var child1 = new BTreeNode<int, string>(3, new KeyValuePair<int, string>(30, "C"));
            child1.InsertKeyValue(new KeyValuePair<int, string>(50, "D"));

            var child2 = new BTreeNode<int, string>(3, new KeyValuePair<int, string>(150, "E"));
            var child3 = new BTreeNode<int, string>(3, new KeyValuePair<int, string>(400, "F"));
            child3.InsertKeyValue(new KeyValuePair<int, string>(500, "F"));

            root.InsertChild(child1);
            root.InsertChild(child2);
            root.InsertChild(child3);

            var tree = new BTree<int, string>(3) { Root = root };
            BTreeTestsUtils.HasBTreeProperties(tree, 7, 7, 4);

            Assert.IsTrue(tree.Delete(150));
            BTreeTestsUtils.HasBTreeProperties(tree, 6, 6, 4);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeaf_ExpectsToTriggerJoinAndLeftRotateOnANodeWithChildren()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(60, "A"));

            var node2 = new BTreeNode<int, string>(3);
            node2.InsertKeyValue(new KeyValuePair<int, string>(30, "B"));

            var node3 = new BTreeNode<int, string>(3);
            node3.InsertKeyValue(new KeyValuePair<int, string>(200, "C"));
            node3.InsertKeyValue(new KeyValuePair<int, string>(300, "D"));

            var node4 = new BTreeNode<int, string>(3);
            node4.InsertKeyValue(new KeyValuePair<int, string>(10, "E"));

            var node5 = new BTreeNode<int, string>(3);
            node5.InsertKeyValue(new KeyValuePair<int, string>(50, "F"));

            var node6 = new BTreeNode<int, string>(3);
            node6.InsertKeyValue(new KeyValuePair<int, string>(150, "G"));

            var node7 = new BTreeNode<int, string>(3);
            node7.InsertKeyValue(new KeyValuePair<int, string>(250, "H"));

            var node8 = new BTreeNode<int, string>(3);
            node8.InsertKeyValue(new KeyValuePair<int, string>(500, "I"));

            node1.InsertChild(node2);
            node1.InsertChild(node3);

            node2.InsertChild(node4);
            node2.InsertChild(node5);

            node3.InsertChild(node6);
            node3.InsertChild(node7);
            node3.InsertChild(node8);

            var tree = new BTree<int, string>(3)
            {
                Root = node1
            };
            BTreeTestsUtils.HasBTreeProperties(tree, 9, 9, 8);
            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBTreeProperties(tree, 8, 8, 7);
        }

        [TestMethod]
        public void RotateLeft_EmptyNodeWithMinOneFullSibling_ExpectsChildrenToBeRotated()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            var node2 = new BTreeNode<int, string>(3);

            var node3 = new BTreeNode<int, string>(3);
            node3.InsertKeyValue(new KeyValuePair<int, string>(20, "B"));
            node3.InsertKeyValue(new KeyValuePair<int, string>(30, "C"));

            var node4 = new BTreeNode<int, string>(3);
            node4.InsertKeyValue(new KeyValuePair<int, string>(15, "D"));

            var node5 = new BTreeNode<int, string>(3);
            node5.InsertKeyValue(new KeyValuePair<int, string>(25, "E"));

            var node6 = new BTreeNode<int, string>(3);
            node6.InsertKeyValue(new KeyValuePair<int, string>(35, "F"));

            var node7 = new BTreeNode<int, string>(3);
            node7.InsertKeyValue(new KeyValuePair<int, string>(1, "G"));

            node1.InsertChild(node2);
            node1.InsertChild(node3);

            node2.InsertChild(node7);

            node3.InsertChild(node4);
            node3.InsertChild(node5);
            node3.InsertChild(node6);

            var tree = new BTree<int, string>(3) { Root = node1 };

            tree.RotateLeft(node2, node3, 0);
            BTreeTestsUtils.HasBTreeProperties(tree, 7, 7, 7);
        }

        [TestMethod]
        public void RotateRight_EmptyNodeWithMinOneFullLeftSibling_ExpectsChildrenToBeRotated()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "A"));

            var node2 = new BTreeNode<int, string>(3);
            node2.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node2.InsertKeyValue(new KeyValuePair<int, string>(80, "C"));

            var node3 = new BTreeNode<int, string>(3);
            node3.InsertKeyValue(new KeyValuePair<int, string>(100, "D"));

            var node4 = new BTreeNode<int, string>(3);
            node4.InsertKeyValue(new KeyValuePair<int, string>(40, "D"));

            var node5 = new BTreeNode<int, string>(3);
            node5.InsertKeyValue(new KeyValuePair<int, string>(70, "E"));

            var node6 = new BTreeNode<int, string>(3);
            node6.InsertKeyValue(new KeyValuePair<int, string>(90, "F"));

            var node7 = new BTreeNode<int, string>(3);
            node7.InsertKeyValue(new KeyValuePair<int, string>(150, "G"));

            node1.InsertChild(node2);
            node1.InsertChild(node3);

            node2.InsertChild(node4);
            node2.InsertChild(node5);
            node2.InsertChild(node6);

            node3.InsertChild(node7);
            /* This is to be able to test RotateLeft without re-ordering children. */
            node3.RemoveKey(100);

            var tree = new BTree<int, string>(3)
            {
                Root = node1
            };
            tree.RotateRight(node3, node2, 0);
            BTreeTestsUtils.HasBTreeProperties(tree, 7, 7, 7);
        }

        [TestMethod]
        public void GetMaxNode_OnAllSubTreesInTree_ExpectsCorrectValuesForMaxKeyInSubtree()
        {
            var node = _tree.Search(_tree.Root, 100);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(600, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 50);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(90, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 300);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(600, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 20);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(30, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 80);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(90, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 10);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(10, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 30);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(30, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 60);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(60, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 90);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(90, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 200);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(270, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 150);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(150, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 250);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(270, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 270);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(270, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 500);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(600, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 400);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(400, node.GetMaxKey().Key);

            node = _tree.Search(_tree.Root, 600);
            node = _tree.GetMaxNode(node);
            Assert.AreEqual(600, node.GetMaxKey().Key);
        }
    }
}
