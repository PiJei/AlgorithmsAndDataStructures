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
using System.Linq;
using CSFundamentals.DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class BTreeTests
    {
        private BTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new BTree<int, string>(3);
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
        public void BTree_FindLeafToInsertKey_Test_1()
        {
            var leaf1 = _tree.FindLeafToInsertKey(_tree.Root, 5);
            Assert.AreEqual(1, leaf1.KeyCount);
            Assert.IsTrue(leaf1.IsLeaf());
            Assert.AreEqual(10, leaf1.GetKey(0));

            var leaf2 = _tree.FindLeafToInsertKey(_tree.Root, 800);
            Assert.AreEqual(1, leaf2.KeyCount);
            Assert.IsTrue(leaf2.IsLeaf());
            Assert.AreEqual(600, leaf2.GetKey(0));

            var leaf3 = _tree.FindLeafToInsertKey(_tree.Root, 75);
            Assert.AreEqual(1, leaf3.KeyCount);
            Assert.IsTrue(leaf3.IsLeaf());
            Assert.AreEqual(60, leaf3.GetKey(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BTree_FindLeafToInsertKey_Test_DuplicateKey()
        {
            var leaf5 = _tree.FindLeafToInsertKey(_tree.Root, 50);
        }

        [TestMethod]
        public void BTree_Build_Test()
        {
            HasBTreeProperties(_tree, 16, 15);
        }

        [TestMethod]
        public void BTree_Insert_Test()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            Assert.IsTrue(HasBTreeProperties(tree, 0, 0));

            tree.Insert(new KeyValuePair<int, string>(50, "A"));
            Assert.IsTrue(HasBTreeProperties(tree, 1, 1));

            tree.Insert(new KeyValuePair<int, string>(10, "B"));
            Assert.IsTrue(HasBTreeProperties(tree, 2, 1));

            tree.Insert(new KeyValuePair<int, string>(100, "C"));
            Assert.IsTrue(HasBTreeProperties(tree, 3, 3));

            tree.Insert(new KeyValuePair<int, string>(200, "D"));
            Assert.IsTrue(HasBTreeProperties(tree, 4, 3));

            tree.Insert(new KeyValuePair<int, string>(20, "E"));
            Assert.IsTrue(HasBTreeProperties(tree, 5, 3));

            tree.Insert(new KeyValuePair<int, string>(300, "F"));
            Assert.IsTrue(HasBTreeProperties(tree, 6, 4));

            tree.Insert(new KeyValuePair<int, string>(30, "G"));
            Assert.IsTrue(HasBTreeProperties(tree, 7, 7));

            tree.Insert(new KeyValuePair<int, string>(500, "H"));
            Assert.IsTrue(HasBTreeProperties(tree, 8, 7));

            tree.Insert(new KeyValuePair<int, string>(250, "I"));
            Assert.IsTrue(HasBTreeProperties(tree, 9, 8));

            tree.Insert(new KeyValuePair<int, string>(400, "J"));
            Assert.IsTrue(HasBTreeProperties(tree, 10, 8));

            tree.Insert(new KeyValuePair<int, string>(270, "K"));
            Assert.IsTrue(HasBTreeProperties(tree, 11, 8));

            tree.Insert(new KeyValuePair<int, string>(600, "L"));
            Assert.IsTrue(HasBTreeProperties(tree, 12, 10));

            tree.Insert(new KeyValuePair<int, string>(150, "M"));
            Assert.IsTrue(HasBTreeProperties(tree, 13, 10));

            tree.Insert(new KeyValuePair<int, string>(80, "N"));
            Assert.IsTrue(HasBTreeProperties(tree, 14, 11));

            tree.Insert(new KeyValuePair<int, string>(60, "O"));
            Assert.IsTrue(HasBTreeProperties(tree, 15, 11));

            tree.Insert(new KeyValuePair<int, string>(90, "P"));
            Assert.IsTrue(HasBTreeProperties(tree, 16, 15));

            Assert.AreEqual(1, tree.Root.KeyCount);
            Assert.AreEqual(100, tree.Root.GetKeyValue(0).Key);
            Assert.AreEqual("C", tree.Root.GetKeyValue(0).Value, ignoreCase: true);
        }

        [TestMethod]
        public void BTree_InOrderTraversal_Test()
        {
            List<KeyValuePair<int, string>> keyValues = new List<KeyValuePair<int, string>>();
            _tree.InOrderTraversal(_tree.Root, keyValues);
            Assert.AreEqual(16, keyValues.Count);
            for (int i = 0; i < keyValues.Count - 1; i++)
            {
                Assert.IsTrue(keyValues[i].Key < keyValues[i + 1].Key);
            }
        }


        [TestMethod]
        public void BTree_Search_Test()
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
        public void BTree_Search_Test_Fail_1()
        {
            var node1 = _tree.Search(_tree.Root, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BTree_Search_Test_Fail_2()
        {
            var node1 = _tree.Search(_tree.Root, 55);
        }

        [TestMethod]
        public void BTree_Delete_Test_1()
        {
            Assert.IsTrue(_tree.Delete(100));
            Assert.AreEqual(2, _tree.Root.KeyCount);
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_2()
        {
            Assert.IsTrue(_tree.Delete(50));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_3()
        {
            Assert.IsTrue(_tree.Delete(300));
            HasBTreeProperties(_tree, 15, 15);
        }

        [TestMethod]
        public void BTree_Delete_Test_4()
        {
            Assert.IsTrue(_tree.Delete(20));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_5()
        {
            Assert.IsTrue(_tree.Delete(80));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_6()
        {
            Assert.IsTrue(_tree.Delete(200));
            HasBTreeProperties(_tree, 15, 15);
        }

        [TestMethod]
        public void BTree_Delete_Test_7()
        {
            Assert.IsTrue(_tree.Delete(500));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_8()
        {
            Assert.IsTrue(_tree.Delete(10));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_9()
        {
            Assert.IsTrue(_tree.Delete(30));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_10()
        {
            Assert.IsTrue(_tree.Delete(60));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_11()
        {
            Assert.IsTrue(_tree.Delete(90));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_12()
        {
            Assert.IsTrue(_tree.Delete(150));
            HasBTreeProperties(_tree, 15, 15);
        }

        [TestMethod]
        public void BTree_Delete_Test_13()
        {
            Assert.IsTrue(_tree.Delete(250));
            HasBTreeProperties(_tree, 15, 15);
        }

        [TestMethod]
        public void BTree_Delete_Test_14()
        {
            Assert.IsTrue(_tree.Delete(270));
            HasBTreeProperties(_tree, 15, 15);
        }

        [TestMethod]
        public void BTree_Delete_Test_15()
        {
            Assert.IsTrue(_tree.Delete(400));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_16()
        {
            Assert.IsTrue(_tree.Delete(600));
            HasBTreeProperties(_tree, 15, 11);
        }

        [TestMethod]
        public void BTree_Delete_Test_17()
        {
            Assert.IsTrue(_tree.Delete(100));
            HasBTreeProperties(_tree, 15, 11);

            Assert.IsTrue(_tree.Delete(20));
            HasBTreeProperties(_tree, 14, 10);

            Assert.IsTrue(_tree.Delete(250));
            HasBTreeProperties(_tree, 13, 10);

            Assert.IsTrue(_tree.Delete(600));
            HasBTreeProperties(_tree, 12, 8);

            Assert.IsTrue(_tree.Delete(270));
            HasBTreeProperties(_tree, 11, 8);

            Assert.IsTrue(_tree.Delete(60));
            HasBTreeProperties(_tree, 10, 8);

            Assert.IsTrue(_tree.Delete(10));
            HasBTreeProperties(_tree, 9, 8);

            Assert.IsTrue(_tree.Delete(300));
            HasBTreeProperties(_tree, 8, 7);

            Assert.IsTrue(_tree.Delete(80));
            HasBTreeProperties(_tree, 7, 4);

            Assert.IsTrue(_tree.Delete(150));
            HasBTreeProperties(_tree, 6, 4);

            Assert.IsTrue(_tree.Delete(400));
            HasBTreeProperties(_tree, 5, 4);

            Assert.IsTrue(_tree.Delete(30));
            HasBTreeProperties(_tree, 4, 3);

            Assert.IsTrue(_tree.Delete(90));
            HasBTreeProperties(_tree, 3, 3);

            Assert.IsTrue(_tree.Delete(500));
            HasBTreeProperties(_tree, 2, 1);

            Assert.IsTrue(_tree.Delete(50));
            HasBTreeProperties(_tree, 1, 1);

            Assert.IsTrue(_tree.Delete(200));
            HasBTreeProperties(_tree, 0, 0);
        }

        [TestMethod]
        public void BTree_Delete_Test_18()
        {
            // TODO: Mixed order consecutive deletes
        }


        /// <summary>
        /// Tree has only one node: root, and root has 1 key.
        /// </summary>
        [TestMethod]
        public void BTree_Delete_Test_19()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            HasBTreeProperties(tree, 1, 1);

            /* Deleting the only key in the only node of the tree. */
            Assert.IsTrue(tree.Delete(10));
            HasBTreeProperties(tree, 0, 0);
        }

        [TestMethod]
        public void BTree_Delete_Test_20()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(100, "B"));
            HasBTreeProperties(tree, 2, 1);

            /* Deleting 1 out of 2 keys in the only node of the tree. */
            Assert.IsTrue(tree.Delete(100));
            HasBTreeProperties(tree, 1, 1);

            /* Deleting a non-existing key. */
            Assert.IsFalse(tree.Delete(50));
            HasBTreeProperties(tree, 1, 1);

            /* Deleting the only key in the only node of the tree. */
            Assert.IsTrue(tree.Delete(10));
            HasBTreeProperties(tree, 0, 0);

            /* Deleting a key in a tree with no node. */
            Assert.IsFalse(tree.Delete(150));
            HasBTreeProperties(tree, 0, 0);
        }

        [TestMethod]
        public void BTree_Delete_Test_21()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            HasBTreeProperties(tree, 3, 3);

            Assert.IsTrue(tree.Delete(20));
            HasBTreeProperties(tree, 2, 1);
        }

        [TestMethod]
        public void BTree_Delete_Test_22()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            HasBTreeProperties(tree, 3, 3);

            Assert.IsTrue(tree.Delete(10));
            HasBTreeProperties(tree, 2, 1);

        }

        [TestMethod]
        public void BTree_Delete_Test_23()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            HasBTreeProperties(tree, 3, 3);

            Assert.IsTrue(tree.Delete(30));
            HasBTreeProperties(tree, 2, 1);
        }

        [TestMethod]
        public void BTree_Delete_Test_24()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            HasBTreeProperties(tree, 4, 3);

            Assert.IsTrue(tree.Delete(30));
            HasBTreeProperties(tree, 3, 3);
        }

        [TestMethod]
        public void BTree_Delete_Test_25()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            HasBTreeProperties(tree, 4, 3);

            Assert.IsTrue(tree.Delete(40));
            HasBTreeProperties(tree, 3, 3);
        }

        [TestMethod]
        public void BTree_Delete_Test_26()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            HasBTreeProperties(tree, 4, 3);

            Assert.IsTrue(tree.Delete(10));
            HasBTreeProperties(tree, 3, 3);
        }

        [TestMethod]
        public void BTree_Delete_Test_27()
        {
            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Insert(new KeyValuePair<int, string>(10, "A"));
            tree.Insert(new KeyValuePair<int, string>(20, "B"));
            tree.Insert(new KeyValuePair<int, string>(30, "C"));
            tree.Insert(new KeyValuePair<int, string>(40, "D"));
            HasBTreeProperties(tree, 4, 3);

            Assert.IsTrue(tree.Delete(20));
            HasBTreeProperties(tree, 3, 3);
        }


        [TestMethod]
        public void BTree_Delete_Test_28()
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

            BTree<int, string> tree = new BTree<int, string>(3);
            tree.Root = root;

            Assert.IsTrue(tree.Delete(150));
            HasBTreeProperties(tree, 6, 4);
        }

        // TOD0: Compute levels and after each insert confirm it

        public bool HasBTreeProperties<T1, T2>(BTree<T1, T2> tree, int expectedKeyCount, int expectedNodeCount) where T1 : IComparable<T1>
        {
            List<BTreeNode<T1, T2>> nodes = new List<BTreeNode<T1, T2>>();
            DFS(tree.Root, nodes);
            Assert.AreEqual(expectedNodeCount, nodes.Count);

            int keyCount = 0;

            /* Checking whether all the nodes are proper BTree nodes. */
            foreach (BTreeNode<T1, T2> node in nodes)
            {
                Assert.IsTrue(BTreeNodeTests.HasBTreeNodeProperties(node));
                keyCount += node.KeyCount;
            }

            /* Check that key count of all the nodes matches the expected key count. */
            Assert.AreEqual(expectedKeyCount, keyCount);

            /* Get the sorted key list and make sure it is sorted. */
            List<KeyValuePair<T1, T2>> sortedKeys = new List<KeyValuePair<T1, T2>>();
            tree.InOrderTraversal(tree.Root, sortedKeys);
            Assert.AreEqual(expectedKeyCount, sortedKeys.Count);
            for (int i = 0; i < sortedKeys.Count - 1; i++)
            {
                Assert.IsTrue(sortedKeys[i].Key.CompareTo(sortedKeys[i + 1].Key) < 0);
            }

            /* TODO Check all the leave nodes are at the same level, or one level apart? */

            return true;
        }

        /// <summary>
        /// TODO: How to make this to use the dfs I have in the algorithms? 
        /// </summary>
        public void DFS<T1, T2>(BTreeNode<T1, T2> node, List<BTreeNode<T1, T2>> nodes) where T1 : IComparable<T1>
        {
            if (node != null)
            {
                nodes.Add(node);
                for (int i = 0; i < node.ChildrenCount; i++)
                {
                    DFS(node.GetChild(i), nodes);
                }
            }
        }
    }
}
