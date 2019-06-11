#region copyright
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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.Trees.Nary
{
    /// <summary>
    /// Tests BTreeNode implementation by a 2-3 BTree Node.
    /// </summary>
    [TestClass]
    public class _2_3_BTreeNodeTests
    {
        /// <summary>
        /// Tests the correctness of constructor in computing minimum and maximum branching degrees and minimum and maximum number of keys in a BTree node. 
        /// </summary>
        [TestMethod]
        public void Constructor_CheckingDegrees()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MinBranchingDegree);
            Assert.AreEqual(3, node.MaxBranchingDegree);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is leaf over a child less node. Expects true. 
        /// </summary>
        [TestMethod]
        public void IsLeaf_ChildLessNode_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.IsTrue(node.IsLeaf());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is leaf over a node with one child. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsLeaf_NodeHasOneChild_ExpectsFalse()
        {
            var node1 = new BTreeNode<int, string>(3);
            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsFalse(node1.IsLeaf());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is root over a node with no parent. Expects true. 
        /// </summary>
        [TestMethod]
        public void IsRoot_NodeHasNoParent_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.IsTrue(node.IsRoot());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is root over a node with a parent. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsRoot_NodeHasParent_ExpectsFalse()
        {
            var node1 = new BTreeNode<int, string>(3);
            var node2 = new BTreeNode<int, string>(3);
            node1.InsertChild(node2);
            Assert.IsFalse(node2.IsRoot());
        }

        /// <summary>
        /// Tests the correctness of finding min key in a node. 
        /// </summary>
        [TestMethod]
        public void GetMinKey_NodeHasKeys_FindsMinCorrectly()
        {
            var node = new BTreeNode<int, string>(3);

            /* Testing with 3 keys. */
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            Assert.AreEqual(10, node.GetMinKey().Key);
            Assert.AreEqual("A", node.GetMinKey().Value, ignoreCase: false);
        }

        /// <summary>
        /// Tests the correctness of finding max key in a node. 
        /// </summary>
        [TestMethod]
        public void GetMaxKey_NodeHasKeys_FindsMaxCorrectly()
        {
            var node1 = new BTreeNode<int, string>(3);

            /* Testing with 3 keys. */
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            Assert.AreEqual(100, node1.GetMaxKey().Key);
            Assert.AreEqual("C", node1.GetMaxKey().Value, ignoreCase: false);
        }

        /// <summary>
        /// Tests the correctness of comparing a BTree node to a null node. 
        /// </summary>
        [TestMethod]
        public void Compare_OtherIsNull_ExpectsBigger()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.CompareTo(null));
        }

        /// <summary>
        /// Tests the correctness of comparing two empty nodes (have no keys). 
        /// </summary>
        [TestMethod]
        public void Compare_TwoEmptyNodes_ExpectsEqual()
        {
            var node1 = new BTreeNode<int, string>(3);
            var node2 = new BTreeNode<int, string>(3);
            Assert.AreEqual(0, node1.CompareTo(node2));
        }

        /// <summary>
        /// Tests the correctness of comparing a non empty node to an empty node. 
        /// </summary>
        [TestMethod]
        public void Compare_NonEmptyToEmpty_ExpectsNonEmptyToBeBigger()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node1.CompareTo(node2));
        }

        /// <summary>
        /// Tests the correctness of comparing two nodes each with one key. 
        /// </summary>
        [TestMethod]
        public void Compare_TwoNodesEachWithOneKey_ExpectsNodeWithSmallerKeyToBeSmaller()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(3);
            node2.InsertKeyValue(new KeyValuePair<int, string>(50, "B2"));
            Assert.AreEqual(-1, node1.CompareTo(node2));
        }

        /// <summary>
        /// Tests the correctness of comparing two nodes that have the same min key but different max keys. Expects equality. 
        /// </summary>
        [TestMethod]
        public void Compare_TwoNodesWithEqualMinKeyAndDifferentMaxKey_ExpectsEqual()
        {
            var node1 = new BTreeNode<int, string>(3);
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(3);
            node2.InsertKeyValue(new KeyValuePair<int, string>(50, "B2"));
            node2.InsertKeyValue(new KeyValuePair<int, string>(10, "A2"));

            /* Notice that in a B-Tree node we do not expect 2 children to have the same min key. Thus these 2 nodes are expected to be equal, and considered duplicates to prevent inserting one of them in the tree.*/
            Assert.AreEqual(0, node1.CompareTo(node2));
        }

        /// <summary>
        /// Tests the correctness of inserting several distinct keys in the BTree node. 
        /// </summary>
        [TestMethod]
        public void InsertKey_SeveralKeys_ExpectsAscendingOrderAmongKeys()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            Assert.AreEqual(0, node1.GetKeyIndex(10));
            Assert.AreEqual(1, node1.GetKeyIndex(50));
            Assert.AreEqual(2, node1.GetKeyIndex(100));
        }

        /// <summary>
        /// Tests the correctness of inserting several keys some with duplicates in a BTree node. 
        /// </summary>
        [TestMethod]
        public void InsertKey_Duplicates_ExpectsOnlyOneKey()
        {
            var node = new BTreeNode<int, string>(3);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);

            /* Expects this operation to reject insertion of duplicates, and thus the keyCount should not change.*/
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "B"));
            Assert.AreEqual(1, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of inserting several children in a node. 
        /// </summary>
        [TestMethod]
        public void InsertChild_SeveralChildren_ExpectsAscendingOrderAmongChildrenBasedOnTheirKeyRange()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKeyValue(new KeyValuePair<int, string>(9, "E"));

            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKeyValue(new KeyValuePair<int, string>(55, "F"));
            child2.InsertKeyValue(new KeyValuePair<int, string>(70, "G"));

            node1.InsertChild(child2);
            node1.InsertChild(child1);

            Assert.IsTrue(ReferenceEquals(node1, child1.GetParent()));
            Assert.IsTrue(ReferenceEquals(node1, child2.GetParent()));

            Assert.AreEqual(0, node1.GetChildIndex(child1));
            Assert.AreEqual(1, node1.GetChildIndex(child2));
        }

        /// <summary>
        /// Tests the correctness of inserting duplicate children in a node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertChild_Duplicates_ThrowsException()
        {
            var node1 = new BTreeNode<int, string>(3);

            node1.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node1.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(5, "D"));
            child1.InsertKeyValue(new KeyValuePair<int, string>(9, "E"));

            node1.InsertChild(child1);
            node1.InsertChild(child1);
        }

        /// <summary>
        /// Tests the correctness of splitting an empty node. 
        /// </summary>
        [TestMethod]
        public void Split_EmptyNode_ExpectsNullForTheNewNode()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MaxKeys); /* Thus to be overFlown (which is the condition for split) node should have 3 keys. */

            var newNode = node.Split();
            Assert.IsNull(newNode);
        }

        /// <summary>
        /// Tests the correctness of splitting a minFull node. Expects the split operation not to be executed. Note that in this implementation Split operation is only permitted on an overFlown node. 
        /// </summary>
        [TestMethod]
        public void Split_NodeIsMinFull_ExpectsNullForTheNewNode()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MaxKeys); /* Thus to be overFlown (which is the condition for split) node should have 3 keys. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            /* Node has MinKeys key, and thus is not MinOneFull, to be splittable. */
            Assert.IsTrue(!node.IsMinOneFull());
            Assert.IsTrue(node.IsMinFull());

            var newNode = node.Split();
            Assert.IsNull(newNode);
        }

        /// <summary>
        /// Tests the correctness of splitting a full node. Expects the split operation not to be executed. Note that in this implementation Split operation is only permitted on an overFlown node.  
        /// </summary>
        [TestMethod]
        public void Split_NodeIsFull_ExpectsNullForTheNewNode()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MaxKeys); /* Thus to be overFlown (which is the condition for split) node should have 3 keys. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            var newNode = node.Split();
            Assert.IsNull(newNode);
        }

        /// <summary>
        /// Tests the correctness of splitting an overFlown node. Expects a successful split. Note that in this implementation Split operation is only permitted on an overFlown node. 
        /// </summary>
        [TestMethod]
        public void Split_NodeIsOverFlownAndHasNoChildren_ExpectsSuccessfulSplitForKeys()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(2, node.MaxKeys); /* Thus to be overFlown (which is the condition for split) node should have 3 keys. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            var newNode = node.Split();
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties<BTreeNode<int, string>, int, string>(node));
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties<BTreeNode<int, string>, int, string>(newNode));
            Assert.AreEqual(2, node.KeyCount);
            Assert.AreEqual(1, newNode.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of splitting an overFlown node with children. Expects a successful split of keys and children. Note that in this implementation Split operation is only permitted on an overFlown node. 
        /// </summary>
        [TestMethod]
        public void Split_NodeIsOverFlownAndHasChildren_ExpectsSuccessfulSplitForKeysAndChildren()
        {
            var node = new BTreeNode<int, string>(3);

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(200, "C"));

            var child1 = new BTreeNode<int, string>(3);
            child1.InsertKeyValue(new KeyValuePair<int, string>(10, "D"));
            node.InsertChild(child1);

            var child2 = new BTreeNode<int, string>(3);
            child2.InsertKeyValue(new KeyValuePair<int, string>(30, "E"));
            node.InsertChild(child2);

            var child3 = new BTreeNode<int, string>(3);
            child3.InsertKeyValue(new KeyValuePair<int, string>(100, "F"));
            node.InsertChild(child3);

            var child4 = new BTreeNode<int, string>(3);
            child4.InsertKeyValue(new KeyValuePair<int, string>(300, "G"));
            node.InsertChild(child4);

            BTreeNode<int, string> newNode = node.Split();
            /* At this point we do not expect 'node' to be valid (i.e., HasBTreeNodeProperties(node)==false ), because the key in the middle has not yet moved up, that step is part of split method in the tree itself and not in the node.*/
            Assert.IsTrue(BTreeTestsUtils.HasBTreeNodeProperties<BTreeNode<int, string>, int, string>(newNode));
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is overFlown over an empty node. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsOverFlown_EmptyNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys); /* Thus a node must have 3 keys to be overFlown. */
            Assert.IsFalse(node.IsOverFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is overFlown over minFull node. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsOverFlown_MinFullNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys); /* Thus a node must have 3 keys to be overFlown. */
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount); /* Node has 1 key. */
            Assert.IsFalse(node.IsOverFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is overFlown over a full node. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsOverFlown_FullNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys); /* Thus a node must have 3 keys to be overFlown. */
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));
            Assert.AreEqual(2, node.KeyCount);
            Assert.IsFalse(node.IsOverFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node is overFlown over an overFlown node. Expects false. 
        /// </summary>
        [TestMethod]
        public void IsOverFlown_OverFlownNode_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys); /* Thus a node must have 3 keys to be overFlown. */
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(30, "C"));
            Assert.AreEqual(3, node.KeyCount);
            Assert.IsTrue(node.IsOverFlown());
        }

        /// <summary>
        /// Tests the correctness of finding the key to move up to parent as part of a split operation over an empty node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyValueToMoveUp_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            /* Testing when  the node has no key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        /// <summary>
        /// Tests the correctness of finding the key to move up to parent as part of a split operation over a minFull node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyValueToMoveUp_MinFullNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(2, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            /* Testing when the node has MinKeys key-values. This method is expected only on a node that has at least MinKeys+1 key-values. (In this case at least 2 keys). */
            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        /// <summary>
        /// Tests the correctness of finding the key to move up to parent as part of a split operation over an minOneFull node. Expects the right answer.
        /// </summary>
        [TestMethod]
        public void KeyValueToMoveUp_NodeIsMinOneFull_ExpectsLastKeyInTheNode()
        {
            var node = new BTreeNode<int, string>(3);
            Assert.AreEqual(1, node.MinKeys); /* Thus node needs 1+1 = 2 keys to be MinOneFull, which is the condition for having a key to move up to its parent. */
            Assert.AreEqual(2, node.MaxKeys); /* For a 2-3 BTree node, MinOneFull is the same as Full. */

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));

            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
            Assert.AreEqual(100, keyValue.Key);
            Assert.AreEqual("B", keyValue.Value, ignoreCase: false);
        }
    }
}
