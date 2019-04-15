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

namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    [TestClass]
    public class _2_3_BPlusTreeTests
    {
        /// <summary>
        /// Is a B+ tree. 
        /// To visualize this tree built as in <see cref="Init()"/> method, please <see cref="2-3-BPlus-Tree.png"/>
        /// </summary>
        private BPlusTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new BPlusTree<int, string>(3);
            Dictionary<int, string> keyValues = new Dictionary<int, string>
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
        public void Build_ExpectsACorrectBPlusTree()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
        }

        [TestMethod]
        public void Insert_SeveralKeys_ExpectsTreeToIncreaseInLevelsAfewTimes()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 0, 0, 0);

            tree.Insert(new KeyValuePair<int, string>(50, "A"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 2, 1, 2);

            tree.Insert(new KeyValuePair<int, string>(10, "B"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 2);

            tree.Insert(new KeyValuePair<int, string>(100, "C"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 4, 3, 3);

            tree.Insert(new KeyValuePair<int, string>(200, "D"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 5, 4, 3);

            tree.Insert(new KeyValuePair<int, string>(20, "E"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 7, 5, 4);

            tree.Insert(new KeyValuePair<int, string>(300, "F"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 9, 6, 7);

            tree.Insert(new KeyValuePair<int, string>(30, "G"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 10, 7, 7);

            tree.Insert(new KeyValuePair<int, string>(500, "H"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 11, 8, 7);

            tree.Insert(new KeyValuePair<int, string>(250, "I"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 13, 9, 8);

            tree.Insert(new KeyValuePair<int, string>(400, "J"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 14, 10, 8);

            tree.Insert(new KeyValuePair<int, string>(270, "K"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 16, 11, 10);

            tree.Insert(new KeyValuePair<int, string>(600, "L"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 18, 12, 11);

            tree.Insert(new KeyValuePair<int, string>(150, "M"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 20, 13, 12);

            tree.Insert(new KeyValuePair<int, string>(80, "N"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 22, 14, 16);

            tree.Insert(new KeyValuePair<int, string>(60, "O"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 24, 15, 17);

            tree.Insert(new KeyValuePair<int, string>(90, "P"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 25, 16, 17);

            Assert.AreEqual(1, tree.Root.KeyCount);
            Assert.AreEqual(150, tree.Root.GetKeyValue(0).Key);
            Assert.AreEqual(default(string), tree.Root.GetKeyValue(0).Value, ignoreCase: true);
        }

        [TestMethod]
        public void Search_ForAllExistingKeysInTree_ExpectsSuccess()
        {
            var node1 = _tree.Search(_tree.Root, 100);
            Assert.IsTrue(node1.KeyCount == 2);
            Assert.AreEqual("C", node1.GetKeyValue(node1.GetKeyIndex(100)).Value);
            Assert.IsTrue(node1.IsLeaf());

            var node2 = _tree.Search(_tree.Root, 300);
            Assert.IsTrue(node2.KeyCount == 1);
            Assert.AreEqual("F", node2.GetKeyValue(node2.GetKeyIndex(300)).Value);
            Assert.IsTrue(node2.IsLeaf());

            var node3 = _tree.Search(_tree.Root, 500);
            Assert.IsTrue(node3.KeyCount == 2);
            Assert.AreEqual("H", node3.GetKeyValue(node3.GetKeyIndex(500)).Value);
            Assert.IsTrue(node3.IsLeaf());

            var node4 = _tree.Search(_tree.Root, 200);
            Assert.IsTrue(node4.KeyCount == 1);
            Assert.AreEqual("D", node4.GetKeyValue(node4.GetKeyIndex(200)).Value);
            Assert.IsTrue(node4.IsLeaf());

            var node5 = _tree.Search(_tree.Root, 250);
            Assert.IsTrue(node5.KeyCount == 2);
            Assert.AreEqual("I", node5.GetKeyValue(node5.GetKeyIndex(250)).Value);
            Assert.IsTrue(node5.IsLeaf());

            var node6 = _tree.Search(_tree.Root, 270);
            Assert.IsTrue(node6.KeyCount == 2);
            Assert.AreEqual("K", node6.GetKeyValue(node6.GetKeyIndex(270)).Value);
            Assert.IsTrue(node6.IsLeaf());

            var node7 = _tree.Search(_tree.Root, 400);
            Assert.IsTrue(node7.KeyCount == 2);
            Assert.AreEqual("J", node7.GetKeyValue(node7.GetKeyIndex(400)).Value);
            Assert.IsTrue(node7.IsLeaf());

            var node8 = _tree.Search(_tree.Root, 600);
            Assert.IsTrue(node8.KeyCount == 1);
            Assert.AreEqual("L", node8.GetKeyValue(node8.GetKeyIndex(600)).Value);
            Assert.IsTrue(node8.IsLeaf());

            var node9 = _tree.Search(_tree.Root, 50);
            Assert.IsTrue(node9.KeyCount == 2);
            Assert.AreEqual("A", node9.GetKeyValue(node9.GetKeyIndex(50)).Value);
            Assert.IsTrue(node9.IsLeaf());

            var node10 = _tree.Search(_tree.Root, 20);
            Assert.IsTrue(node10.KeyCount == 2);
            Assert.AreEqual("E", node10.GetKeyValue(node10.GetKeyIndex(20)).Value);
            Assert.IsTrue(node10.IsLeaf());

            var node11 = _tree.Search(_tree.Root, 90);
            Assert.IsTrue(node11.KeyCount == 2);
            Assert.AreEqual("P", node11.GetKeyValue(node11.GetKeyIndex(90)).Value);
            Assert.IsTrue(node11.IsLeaf());

            var node12 = _tree.Search(_tree.Root, 60);
            Assert.IsTrue(node12.KeyCount == 2);
            Assert.AreEqual("O", node12.GetKeyValue(node12.GetKeyIndex(60)).Value);
            Assert.IsTrue(node12.IsLeaf());

            var node13 = _tree.Search(_tree.Root, 80);
            Assert.IsTrue(node13.KeyCount == 2);
            Assert.AreEqual("N", node13.GetKeyValue(node13.GetKeyIndex(80)).Value);
            Assert.IsTrue(node13.IsLeaf());

            var node14 = _tree.Search(_tree.Root, 10);
            Assert.IsTrue(node14.KeyCount == 2);
            Assert.AreEqual("B", node14.GetKeyValue(node14.GetKeyIndex(10)).Value);
            Assert.IsTrue(node14.IsLeaf());

            var node15 = _tree.Search(_tree.Root, 30);
            Assert.IsTrue(node15.KeyCount == 2);
            Assert.AreEqual("G", node15.GetKeyValue(node15.GetKeyIndex(30)).Value);
            Assert.IsTrue(node15.IsLeaf());

            var node16 = _tree.Search(_tree.Root, 150);
            Assert.IsTrue(node16.KeyCount == 1);
            Assert.AreEqual("M", node16.GetKeyValue(node16.GetKeyIndex(150)).Value);
            Assert.IsTrue(node16.IsLeaf());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Search_NotExistingKey_ThrowsException()
        {
            var node1 = _tree.Search(_tree.Root, 5);
        }

        [TestMethod]
        public void FindLeafToInsertKey_NewKeySmallerThanAllKeysInTree_ExpectsTheSparseLeafNodeContainingSmallestKey()
        {
            var leaf = _tree.FindLeafToInsertKey(_tree.Root, 5);
            Assert.AreEqual(2, leaf.KeyCount);
            Assert.IsTrue(leaf.IsLeaf());
            Assert.AreEqual(10, leaf.GetKey(0));
            Assert.AreEqual(20, leaf.GetKey(1));
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
            Assert.AreEqual(2, leaf.KeyCount);
            Assert.IsTrue(leaf.IsLeaf());
            Assert.AreEqual(60, leaf.GetKey(0));
            Assert.AreEqual(80, leaf.GetKey(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindLeafToInsertKey_DuplicateKey_ThrowsException()
        {
            _tree.FindLeafToInsertKey(_tree.Root, 50);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInLeftSubTree_ExpectsRightRotateAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInLeftSubTreeOfTheLeftSubtreeOfRoot_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(50));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_AKeyFromFullLeaf_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInLeftMostLeafOnLeftSubtree_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInAFullLeafNodeOfLeftSubtree_ExpectsSimpleDeleteToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeaf_ExpectsLeftRotationAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInFullLeaf_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInFullLeaf_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInAFullLeafNode_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInAFullLeaf_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInFullLeafWith2Siblings_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheBiggestKeyInFullLeafNode_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(100));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_SmallestKeyInAFullLeaf_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNode_ExpectsLeftRotationAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheSmallestKeyInAFullLeafNodeOfRightSubtree_ExpectsSimpleDeleteAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNode_ExpectsRightRotationAndToReduceBy1Key()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);
        }

        [TestMethod]
        public void Delete_AllNodesInRandomOrder1_ExpectsProperBtreeAfterEachDelete()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);

            Assert.IsTrue(_tree.Delete(100));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);

            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 23, 14, 17);

            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 22, 13, 17);

            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 21, 12, 17);

            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 19, 11, 16);

            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 18, 10, 16);

            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 17, 9, 16);

            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 15, 8, 12);

            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 13, 7, 11);

            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 11, 6, 10);

            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 9, 5, 8);

            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 7, 4, 7);

            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 5, 3, 4);

            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 3, 2, 3);

            Assert.IsTrue(_tree.Delete(50));
             BTreeTestsUtils.HasBPlusTreeProperties(_tree, 2, 1, 2); //TODO: Tree is left in 150/200 index! I think I should have copied 200 to the parent

            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_AllNodesInRandomOrder2_ExpectsProperBtreeAfterEachDelete()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);

            Assert.IsTrue(_tree.Delete(90));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 24, 15, 17);

            Assert.IsTrue(_tree.Delete(400));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 23, 14, 17);

            Assert.IsTrue(_tree.Delete(80));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 22, 13, 17);

            Assert.IsTrue(_tree.Delete(600));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 20, 12, 16);

            Assert.IsTrue(_tree.Delete(100));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 18, 11, 15);

            Assert.IsTrue(_tree.Delete(20));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 17, 10, 15);

            Assert.IsTrue(_tree.Delete(270));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 16, 9, 15);

            Assert.IsTrue(_tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 15, 8, 15);

            Assert.IsTrue(_tree.Delete(250));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 13, 7, 11);

            Assert.IsTrue(_tree.Delete(50));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 11, 6, 9);

            Assert.IsTrue(_tree.Delete(200));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 9, 5, 8);

            Assert.IsTrue(_tree.Delete(30));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 7, 4, 7);

            Assert.IsTrue(_tree.Delete(150));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 5, 3, 4);

            Assert.IsTrue(_tree.Delete(300));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 3, 2, 3);

            Assert.IsTrue(_tree.Delete(60));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 2, 1, 2);

            Assert.IsTrue(_tree.Delete(500));
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInTree_ExpectsNoNodeAndNoKeyAfter()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 2, 1, 2);

            /* Deleting the only key in the only leaf node of the tree. */
            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 0, 0, 0);
        }

        [TestMethod]
        public void Delete_BiggestKeyInTheOnlyLeafNodeOfTree_ExpectsToReduceBy1Key()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(100, "B"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 3);

            /* Deleting 1 out of 2 keys in the only leaf node of the tree. */
            Assert.IsTrue(tree.Delete(100));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 2, 1, 2);
        }

        [TestMethod]
        public void Delete_NonExistingKey_ExpectsFailure()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(100, "B"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 3);

            /* Deleting a non-existing key. */
            Assert.IsFalse(tree.Delete(50));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 3);
        }

        [TestMethod]
        public void Delete_TheKeyInFullLeafNode_ExpectsSimpleDeleteAndReduceBy1Key()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 4, 3, 3);

            Assert.IsTrue(tree.Delete(20));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 3);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNode_ExpectsToTriggerLeftRotateAndReduceBy1Key()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 4, 3, 3);

            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 3);
        }

        [TestMethod]
        public void Delete_KeyInFullLeaf_ExpectsToReduceBy1Key()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 6, 4, 4);

            Assert.IsTrue(tree.Delete(30));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 5, 3, 4);
        }

        [TestMethod]
        public void Delete_TheOnlyKeyInLeafNodeWithMinOneFullSibling_ExpectsToTriggerLeftRotate()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 6, 4, 4);

            Assert.IsTrue(tree.Delete(10));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 5, 3, 4);
        }
    }
}
