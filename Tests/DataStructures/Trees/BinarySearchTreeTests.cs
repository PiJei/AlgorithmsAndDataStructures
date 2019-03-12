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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.Trees;
using System;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private BinarySearchTreeNode<int, string> _root;
        private BinarySearchTree<int, string> _tree;

        [TestInitialize]
        public void Init()
        {
            var keyVals = new Dictionary<int, string>
            {
                [40] = "str3",
                [20] = "str1",
                [70] = "str6",
                [50] = "str4",
                [80] = "str7",
                [30] = "str2",
                [60] = "str5",
            };

            _tree = new BinarySearchTree<int, string>();
            _root = _tree.Build(keyVals);
        }

        [TestMethod]
        public void BinarySearchTree_Build_Test()
        {
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);
        }

        [TestMethod]
        public void BinarySearchTree_InOrderTraversal_Test()
        {
            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(7, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Search_Test_Success()
        {
            Assert.AreEqual("str5", _tree.Search(_root, 60).Value, ignoreCase: false);
            Assert.AreEqual("str2", _tree.Search(_root, 30).Value, ignoreCase: false);
            Assert.AreEqual("str7", _tree.Search(_root, 80).Value, ignoreCase: false);
            Assert.AreEqual("str4", _tree.Search(_root, 50).Value, ignoreCase: false);
            Assert.AreEqual("str6", _tree.Search(_root, 70).Value, ignoreCase: false);
            Assert.AreEqual("str1", _tree.Search(_root, 20).Value, ignoreCase: false);
            Assert.AreEqual("str3", _tree.Search(_root, 40).Value, ignoreCase: false);
        }

        [TestMethod]
        public void BinarySearchTree_Search_Test_Failure()
        {
            Assert.IsNull(_tree.Search(_root, 45));
            Assert.IsNull(_tree.Search(null, 30));
        }

        [TestMethod]
        public void BinarySearchTree_Update_Test_Success()
        {
            Assert.IsTrue(_tree.Update(_root, 40, "string3"));

            Assert.IsTrue(_tree.Update(_root, 70, "string6"));
        }

        [TestMethod]
        public void BinarySearchTree_Update_Test_Failue()
        {
            /* Testing the case where root is null. */
            Assert.IsFalse(_tree.Update(null, 40, "string3"));

            /* Testing the case where key does not exist in tree. */
            Assert.IsFalse(_tree.Update(_root, 45, "string3"));
        }

        [TestMethod]
        public void BinarySearchTree_FindMin_Test_Success()
        {
            Assert.AreEqual("str1", _tree.FindMin(_root).Value);
            Assert.AreEqual("str1", _tree.FindMin(_root.LeftChild).Value);
            Assert.AreEqual("str2", _tree.FindMin(_root.LeftChild.RightChild).Value);
            Assert.AreEqual("str4", _tree.FindMin(_root.RightChild).Value);
            Assert.AreEqual("str4", _tree.FindMin(_root.RightChild.LeftChild).Value);
            Assert.AreEqual("str7", _tree.FindMin(_root.RightChild.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMin(_root.RightChild.LeftChild.RightChild).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTree_FindMin_Test_Failure()
        {
            _tree.FindMin(null);
        }

        [TestMethod]
        public void BinarySearchTree_FindMax_Test_Success()
        {
            Assert.AreEqual("str7", _tree.FindMax(_root).Value);
            Assert.AreEqual("str2", _tree.FindMax(_root.LeftChild).Value);
            Assert.AreEqual("str2", _tree.FindMax(_root.LeftChild.RightChild).Value);
            Assert.AreEqual("str7", _tree.FindMax(_root.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMax(_root.RightChild.LeftChild).Value);
            Assert.AreEqual("str7", _tree.FindMax(_root.RightChild.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMax(_root.RightChild.LeftChild.RightChild).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTree_FindMax_Test_Failure()
        {
            _tree.FindMax(null);
        }

        [TestMethod]
        public void BinarySearchTree_Delete_Root_Test()
        {
            _root = _tree.Delete(_root, _root.Key);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete_NodeWith2Children_Test()
        {
            _root = _tree.Delete(_root, 70);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete_NodeWithNoChildren_Test()
        {
            _root = _tree.Delete(_root, 30);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete_NodeWithOneChildren_Test()
        {
            _root = _tree.Delete(_root, 20);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete_MultipleNodes_Test()
        {
            _root = _tree.Delete(_root, 20);
            _root = _tree.Delete(_root, 40);
            _root = _tree.Delete(_root, 50);

            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(4, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete_NotExistingKey_Test()
        {
            _root = _tree.Delete(_root, 15);
            _root = _tree.Delete(_root, 800);
            _root = _tree.Delete(_root, 234);

            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(7, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTree_DeleteMin_Test_1()
        {
            _root = _tree.DeleteMin(_root);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root);
            Assert.AreEqual(30, minNode.Key);
        }

        [TestMethod]
        public void BinarySearchTree_DeleteMin_Test_2()
        {
            _root.RightChild = _tree.DeleteMin(_root.RightChild);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root.RightChild);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root.RightChild, inOrderTraversal);
            Assert.AreEqual(3, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(60, minNode.Key);
        }

        [TestMethod]
        public void BinarySearchTree_DeleteMax_Test_1()
        {
            _root = _tree.DeleteMax(_root);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(6, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMax(_root);
            Assert.AreEqual(70, minNode.Key);
        }

        [TestMethod]
        public void BinarySearchTree_DeleteMax_Test_2()
        {
            _root.RightChild = _tree.DeleteMax(_root.LeftChild);
            HasBinarySearchTreeOrderProperty<BinarySearchTreeNode<int, string>, int, string>(_root.LeftChild);

            var inOrderTraversal = new List<BinarySearchTreeNode<int, string>>();
            TreeNode<BinarySearchTreeNode<int, string>, int, string>.InOrderTraversal(_root.LeftChild, inOrderTraversal);
            Assert.AreEqual(1, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }

            var minNode = _tree.FindMin(_root.RightChild);
            Assert.AreEqual(20, minNode.Key);
        }

        //TODO: This code is repeated between here and binary search tree: remove duplicates
        /// <summary>
        /// Given the root of a binary search tree, checks whether the binary search tree properties hold.
        /// </summary>
        /// <typeparam name="T1">Specifies the type of the keys in tree. </typeparam>
        /// <typeparam name="T2">Specifies the type of the values in tree nodes. </typeparam>
        /// <param name="root">Is the root of a binary search tree. </param>
        public static void HasBinarySearchTreeOrderProperty<T, T1, T2>(T root) where T : ITreeNode<T, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
        {
            if (root != null)
            {
                if (root.LeftChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.LeftChild.Key) > 0);
                    HasBinarySearchTreeOrderProperty<T, T1, T2>(root.LeftChild);
                }
                if (root.RightChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.RightChild.Key) < 0);
                    HasBinarySearchTreeOrderProperty<T, T1, T2>(root.RightChild);
                }
            }
        }
    }
}

