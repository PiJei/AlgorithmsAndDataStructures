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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using CSFundamentals.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Completely test all methods for each number of b-tree instance. 

namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    /// <summary>
    /// Tests BTreeNode implementation by a 3-5 BTree Node.
    /// </summary>
    [TestClass]
    public class _3_5_BTreeNodeTests
    {
        /// <summary>
        /// Tests the correctness of getting max key in an empty B Tree node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetMaxKey_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> maxKeyValue = node.GetMaxKey();
        }

        /// <summary>
        /// Tests the correctness of getting min key in an empty B Tree node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetMinKey_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            KeyValuePair<int, string> minKeyValue = node.GetMinKey();
        }

        /// <summary>
        /// Tests the correctness of detecting whether an empty node is UnderFlown. 
        /// </summary>
        [TestMethod]
        public void IsUnderFlown_EmptyNode_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus to be underFlown a node should have zero or 1 keys. */
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsTrue(node.IsUnderFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with less than MinKeys is underFlown. 
        /// </summary>
        [TestMethod]
        public void IsUnderFlown_NodeHasLessThanMinKeys_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus to be underFlown a node should have zero or 1 keys. */
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.AreEqual(1, node.KeyCount);
            Assert.IsTrue(node.IsUnderFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with MinKeys is underFlown. 
        /// </summary>
        [TestMethod]
        public void IsUnderFlown_NodeMinKeys_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus to be underFlown a node should have zero or 1 keys. */
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));

            Assert.AreEqual(2, node.KeyCount);
            Assert.IsFalse(node.IsUnderFlown());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a minOneFull node is underFlown. 
        /// </summary>
        [TestMethod]
        public void IsUnderFlown_NodeHasMinKeysPlusOne_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus to be underFlown a node should have zero or 1 keys. */
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(20, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(30, "C"));

            Assert.AreEqual(3, node.KeyCount);
            Assert.IsFalse(node.IsUnderFlown());
        }

        /// <summary>
        /// Tests the correctness of getting the key to move up as part of split operation. The node is full and thus expects an exception to be thrown. Note that only when the node has MinKeys+1 keys this operation is successful. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyValueToMoveUp_NodeIsFullAndHasMoreThanMinKeyPlusOneKeys_ExpectsFailure()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* A node should be exactly MinOneFull (have 3 keys) to be able to lend its last key to move up to parent. */
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(60, "D"));

            KeyValuePair<int, string> keyValue = node.KeyValueToMoveUp();
        }

        /// <summary>
        /// Tests the correctness of detecting whether an empty node is full. 
        /// </summary>
        [TestMethod]
        public void IsFull_EmptyNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys); /* Thus a node must have 4 keys to be full. */
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with less than MaxKeys is full. 
        /// </summary>
        [TestMethod]
        public void IsFull_NodeWithLessThanMaxKeys_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys); /* Thus a node must have 4 keys to be full. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "A"));
            Assert.IsFalse(node.IsFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with MaxKeys is full.
        /// </summary>
        [TestMethod]
        public void IsFull_NodeWithMaxKeys_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys); /* Thus a node must have 4 keys to be full. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(200, "D"));
            Assert.IsTrue(node.IsFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with more than MaxKeys is full. 
        /// </summary>
        [TestMethod]
        public void IsFull_NodeWithMoreThanMaxKeys_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys); /* Thus a node must have 4 keys to be full. */

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(200, "D"));
            node.InsertKeyValue(new KeyValuePair<int, string>(40, "E"));
            Assert.IsFalse(node.IsFull());
        }

        /// <summary>
        /// Tests the correctness of finding the index of the current node in its parent's _children array. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIndexAtParentChildren_ParentIsNull_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            int index = node.GetIndexAtParentChildren();
        }

        /// <summary>
        /// Tests the correctness of finding the index of an empty node in its parent's _children array. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetIndexAtParentChildren_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            node.SetParent(new BTreeNode<int, string>(5));
            int index = node.GetIndexAtParentChildren();
        }

        /// <summary>
        /// Tests the correctness of finding the index of an empty node in a random node's _children array. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetIndexAtParentChildren_NodeIsNotAChildAtParent_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.SetParent(new BTreeNode<int, string>(
                5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { new BTreeNode<int, string>(5, new KeyValuePair<int, string>(40, "C")) }));

            int index = node.GetIndexAtParentChildren();
        }

        /// <summary>
        /// Tests the correctness of finding the index of a non-empty node in its parent's _children array. Expects 0 as the index. 
        /// </summary>
        [TestMethod]
        public void GetIndexAtParentChildren_ParentHasNodeAsFirstChild_Expects0AsIndex()
        {
            var node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.SetParent(new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node }));
            int index = node.GetIndexAtParentChildren();
            Assert.AreEqual(0, index);
        }

        /// <summary>
        /// Tests the correctness of finding out whether the node has a left sibling when it is the only child of the parent. 
        /// </summary>
        [TestMethod]
        public void HasLeftSibling_NodeIsOnlyChildOfParent_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.SetParent(new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node }));
            Assert.IsFalse(node.HasLeftSibling());
        }

        /// <summary>
        /// Tests the correctness of finding out whether the 3 children of a node have a left sibling.
        /// </summary>
        [TestMethod]
        public void HasLeftSibling_ParentHas3Children_ExpectsTrueForTwoRightMostChildrenAndFalseForTheLeftMostChild()
        {
            var node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            var node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.IsFalse(node1.HasLeftSibling());
            Assert.IsTrue(node2.HasLeftSibling());
            Assert.IsTrue(node3.HasLeftSibling());
        }

        /// <summary>
        /// Tests the correctness of finding out whether the node has a right sibling when it is the only child of the parent. 
        /// </summary>
        [TestMethod]
        public void HasRightSibling_NodeIsOnlyChildOfParent_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));

            node.SetParent(new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node }));
            Assert.IsFalse(node.HasRightSibling());
        }

        /// <summary>
        /// Tests the correctness of finding out whether the 3 children of a node have a right sibling.
        /// </summary>
        [TestMethod]
        public void HasRightSibling_ParentHas3Children_ExpectsTrueForTwoLeftMostChildrenAndFalseForTheRightMostChild()
        {
            var node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            var node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.IsTrue(node1.HasRightSibling());
            Assert.IsTrue(node3.HasRightSibling());
            Assert.IsFalse(node2.HasRightSibling());
        }

        /// <summary>
        /// Tests the correctness of retrieving left siblings of the 3 children of a node. 
        /// </summary>
        [TestMethod]
        public void GetLeftSibling_ParentHas3Children_ExpectsNonNullForTwoRightMostChildrenAndNullForLeftMostChild()
        {
            var node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            var node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(node3, node2.GetLeftSibling());
            Assert.AreEqual(node1, node3.GetLeftSibling());
            Assert.IsNull(node1.GetLeftSibling());
        }

        /// <summary>
        /// Tests the correctness of retrieving right siblings of the 3 children of a node. 
        /// </summary>
        [TestMethod]
        public void GetRightSibling_ParentHas3Children_ExpectsNonNullForTwoLeftMostChildrenAndNullForRightMostChild()
        {
            var node1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var node2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "B"));
            var node3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "C"));

            var parent = new BTreeNode<int, string>(5,
                new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(30, "B") },
                new List<BTreeNode<int, string>> { node1, node2, node3 });

            Assert.AreEqual(node3, node1.GetRightSibling());
            Assert.AreEqual(node2, node3.GetRightSibling());
        }

        /// <summary>
        /// Tests the correctness of detecting whether an empty node has MinKeys.
        /// </summary>
        [TestMethod]
        public void IsMinFull_EmptyNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 2 keys to be MinFull. */
            Assert.AreEqual(4, node.MaxKeys);
            Assert.IsFalse(node.IsMinFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with less than MinKeys has MinKeys.
        /// </summary>
        [TestMethod]
        public void IsMinFull_NodeHasLessThanMinKeys_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 2 keys to be MinFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsMinFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with MinKeys has MinKeys.
        /// </summary>
        [TestMethod]
        public void IsMinFull_NodeHasExactlyMinKeys_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 2 keys to be MinFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsTrue(node.IsMinFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with more than MinKeys has MinKeys.
        /// </summary>
        [TestMethod]
        public void IsMinFull_NodeHasMoreThanMinKeys_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 2 keys to be MinFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsFalse(node.IsMinFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether an empty node has MinKeys+1 keys. 
        /// </summary>
        [TestMethod]
        public void IsMinOneFull_EmptyNode_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 3 keys to be MinOneFull. */
            Assert.AreEqual(4, node.MaxKeys);
            Assert.IsFalse(node.IsMinFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with less than MinKeys+1 has MinKeys+1 keys. 
        /// </summary>
        [TestMethod]
        public void IsMinOneFull_NodeHasLessThanMinKeysPlusOne_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 3 keys to be MinOneFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsMinOneFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with MinKeys has MinKeys+1 keys. 
        /// </summary>
        [TestMethod]
        public void IsMinOneFull_NodeIsMinFull_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 3 keys to be MinOneFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsFalse(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsTrue(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsMinOneFull());

            node.InsertKeyValue(new KeyValuePair<int, string>(150, "E"));
            Assert.IsFalse(node.IsMinOneFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with MinKeys+1 has MinKeys+1 keys. 
        /// </summary>
        [TestMethod]
        public void IsMinOneFull_NodeHasExactlyMinKeysPlusOne_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 3 keys to be MinOneFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            Assert.IsTrue(node.IsMinOneFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with more than MinKeys+1 has MinKeys+1 keys. 
        /// </summary>
        [TestMethod]
        public void IsMinOneFull_NodeHasMoreThanMinKeysPlusOne_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys); /* Thus node must have 3 keys to be MinOneFull. */
            Assert.AreEqual(4, node.MaxKeys);
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(20, "D"));
            Assert.IsFalse(node.IsMinOneFull());
        }

        /// <summary>
        /// Tests the correctness of detecting whether an empty node is empty. 
        /// </summary>
        [TestMethod]
        public void IsEmpty_EmptyNode_ExpectsTrue()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            Assert.IsTrue(node.IsEmpty());
        }

        /// <summary>
        /// Tests the correctness of detecting whether a node with one key is empty. 
        /// </summary>
        [TestMethod]
        public void IsEmpty_NodeHasAtLeastOneKey_ExpectsFalse()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            Assert.IsFalse(node.IsEmpty());

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "B"));
            Assert.IsFalse(node.IsEmpty());
        }

        /// <summary>
        /// Tests the correctness of removing key from an empty node. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveKey_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            /* Testing with an empty node.*/
            node.RemoveKey(10);
        }

        /// <summary>
        /// Tests the correctness of removing a non existing key from a node. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveKey_NotExistingKey_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKey(10);
        }

        /// <summary>
        /// Tests the correctness of removing an existing key from a node. 
        /// </summary>
        [TestMethod]
        public void RemoveKey_ByKey_ExistingKeys_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            node.RemoveKey(100);
            Assert.AreEqual(0, node.KeyCount);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            node.RemoveKey(10);
            Assert.AreEqual(2, node.KeyCount);

            node.RemoveKey(100);
            Assert.AreEqual(1, node.KeyCount);

            node.RemoveKey(50);
            Assert.AreEqual(0, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of removing a key by an index that is out of range. Expects an exception to be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveKey_ByIndex_IndexOutOfRange_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            /* Testing with a non-existing key.*/
            node.RemoveKeyByIndex(2);
        }

        /// <summary>
        /// Tests the correctness of removing a key by an in range index. 
        /// </summary>
        [TestMethod]
        public void RemoveKey_ByIndex_InRangeIndexes_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(2, node.MinKeys);
            Assert.AreEqual(4, node.MaxKeys);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            node.RemoveKeyByIndex(0);
            Assert.AreEqual(0, node.KeyCount);

            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));
            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));

            node.RemoveKeyByIndex(1);
            Assert.AreEqual(2, node.KeyCount);

            node.RemoveKeyByIndex(1);
            Assert.AreEqual(1, node.KeyCount);

            node.RemoveKeyByIndex(0);
            Assert.AreEqual(0, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of removing a child from a node that has no children. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveChild_ByIndex_ChildLessNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChildByIndex(2);
        }

        /// <summary>
        /// Tests the correctness of removing a child when index is out of range. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveChild_ByIndex_IndexOutOfRange_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChildByIndex(2);
        }

        /// <summary>
        /// Tests the correctness of removing a child when index is in range. 
        /// </summary>
        [TestMethod]
        public void RemoveChild_ByIndex_InRangeIndexes_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "B")));
            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "C")));

            Assert.AreEqual(3, node.ChildrenCount);

            node.RemoveChildByIndex(2);
            Assert.AreEqual(2, node.ChildrenCount);

            node.RemoveChildByIndex(0);
            Assert.AreEqual(1, node.ChildrenCount);

            node.RemoveChildByIndex(0);
            Assert.AreEqual(0, node.ChildrenCount);
        }

        /// <summary>
        /// Tests the correctness of removing a an empty child from an empty node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveChild_ByKey_EmptyNodeEmptyChild_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with no children. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        /// <summary>
        /// Tests the correctness of removing an empty child. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveChild_ByKey_EmptyChild_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertChild(new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A")));
            /* Testing with a non-existing child. */
            node.RemoveChild(new BTreeNode<int, string>(5));
        }

        /// <summary>
        /// Tests the correctness of removing an existing child. 
        /// </summary>
        [TestMethod]
        public void RemoveChild_ByKey_ExistingKeys_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            node.InsertChild(child1);

            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(50, "B"));
            node.InsertChild(child2);

            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(100, "C"));
            node.InsertChild(child3);

            Assert.AreEqual(3, node.ChildrenCount);

            node.RemoveChild(child3);
            Assert.AreEqual(2, node.ChildrenCount);

            node.RemoveChild(child2);
            Assert.AreEqual(1, node.ChildrenCount);

            node.RemoveChild(child1);
            Assert.AreEqual(0, node.ChildrenCount);
        }

        /// <summary>
        /// Tests the correctness of getting a key-value pair from an empty node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKeyValue_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            /* Testing with an empty node. */
            node.GetKeyValue(2);
        }

        /// <summary>
        /// Tests the correctness of getting a key-value pair when index is out of range. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKeyValue_IndexOutOfRange_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));

            /* Testing with a non-empty node, and non-existing index. */
            node.GetKeyValue(2);
        }

        /// <summary>
        /// Tests the correctness of getting a key-value pair when index is in range. 
        /// </summary>
        [TestMethod]
        public void GetKeyValue_InRangeIndexes_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var keyVal1 = node.GetKeyValue(2);
            Assert.AreEqual(100, keyVal1.Key);
            Assert.AreEqual("C", keyVal1.Value, ignoreCase: false);

            var keyVal2 = node.GetKeyValue(1);
            Assert.AreEqual(50, keyVal2.Key);
            Assert.AreEqual("B", keyVal2.Value, ignoreCase: false);

            var keyVal3 = node.GetKeyValue(0);
            Assert.AreEqual(10, keyVal3.Key);
            Assert.AreEqual("A", keyVal3.Value, ignoreCase: false);

            Assert.AreEqual(3, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of getting key from an empty node. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetKey_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKey(3);
        }

        /// <summary>
        /// Tests the correctness of getting an in range key. 
        /// </summary>
        [TestMethod]
        public void GetKey_InRangeIndexes_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var key1 = node.GetKey(2);
            Assert.AreEqual(100, key1);

            var key2 = node.GetKey(1);
            Assert.AreEqual(50, key2);

            var key3 = node.GetKey(0);
            Assert.AreEqual(10, key3);

            Assert.AreEqual(3, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of getting the key index in an empty node. Expects an exception  to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetKeyIndex_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetKeyIndex(2);
        }

        /// <summary>
        /// Tests the correctness of getting the key index of an existing key. 
        /// </summary>
        [TestMethod]
        public void GetKeyIndex_ExistingKey_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.InsertKeyValue(new KeyValuePair<int, string>(10, "A"));
            node.InsertKeyValue(new KeyValuePair<int, string>(50, "B"));
            node.InsertKeyValue(new KeyValuePair<int, string>(100, "C"));

            Assert.AreEqual(3, node.KeyCount);

            var index1 = node.GetKeyIndex(50);
            Assert.AreEqual(1, index1);

            var index2 = node.GetKeyIndex(100);
            Assert.AreEqual(2, index2);

            var index3 = node.GetKeyIndex(10);
            Assert.AreEqual(0, index3);

            Assert.AreEqual(3, node.KeyCount);
        }

        /// <summary>
        /// Tests the correctness of getting a child from an empty node. Expects an exception to be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetChild_EmptyNode_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            node.GetChild(2);
        }

        /// <summary>
        /// Tests the correctness of getting a child when the index is in range.
        /// </summary>
        [TestMethod]
        public void GetChild_InRangeIndexes_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(60, "B"));
            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(150, "C"));
            node.InsertChild(child1);
            node.InsertChild(child2);
            node.InsertChild(child3);

            var c1 = node.GetChild(0);
            Assert.AreEqual(child1, c1);
            var c2 = node.GetChild(1);
            Assert.AreEqual(child2, c2);
            var c3 = node.GetChild(2);
            Assert.AreEqual(child3, c3);
        }

        /// <summary>
        /// Tests the correctness of getting a child index when the node is empty and child is empty as well. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetChildIndex_EmptyNodeEmptyChild_ThrowsException()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child = new BTreeNode<int, string>(5);
            node.GetChildIndex(child);
        }

        /// <summary>
        /// Tests the correctness of getting an existing child index. 
        /// </summary>
        [TestMethod]
        public void GetChildIndex_ExistingKeys_ExpectsSuccess()
        {
            var node = new BTreeNode<int, string>(5);
            Assert.AreEqual(3, node.MinBranchingDegree);
            Assert.AreEqual(5, node.MaxBranchingDegree);

            var child1 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(10, "A"));
            var child2 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(60, "B"));
            var child3 = new BTreeNode<int, string>(5, new KeyValuePair<int, string>(150, "C"));
            node.InsertChild(child1);
            node.InsertChild(child2);
            node.InsertChild(child3);

            Assert.AreEqual(0, node.GetChildIndex(child1));
            Assert.AreEqual(1, node.GetChildIndex(child2));
            Assert.AreEqual(2, node.GetChildIndex(child3));
        }
    }
}
