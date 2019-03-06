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
        private BinaryTreeNode<int, string> _root;
        private BinarySearchTree<int, string> _tree;

        [TestInitialize]
        public void Init()
        {
            var keyVals = new Dictionary<int, string>
            {
                [40] = "str3",
                [20] = "str1",
                [70] = "str8",
                [50] = "str4",
                [80] = "str9",
                [30] = "str2",
                [60] = "str7",
            };

            _tree = new BinarySearchTree<int, string>();
            _root = _tree.Build(keyVals);
        }

        [TestMethod]
        public void BinarySearchTree_Build_Test()
        {
            IsBinarySearchTree(_root);
        }

        [TestMethod]
        public void BinarySearchTree_InOrderTraversal_Test()
        {
            var inOrderTraversal = new List<BinaryTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(7, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        /// <summary>
        /// Given the root of a binary search tree, checks whether the binary search tree properties hold.
        /// </summary>
        /// <typeparam name="T1">Specifies the type of the keys in tree. </typeparam>
        /// <typeparam name="T2">Specifies the type of the values in tree nodes. </typeparam>
        /// <param name="root">Is the root of a binary search tree. </param>
        private void IsBinarySearchTree<T1, T2>(BinaryTreeNode<T1, T2> root) where T1 : IComparable<T1>, IEquatable<T1>
        {
            if (root != null)
            {
                if (root.LeftChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.LeftChild.Key) > 0);
                    IsBinarySearchTree(root.LeftChild);
                }
                if (root.RightChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.RightChild.Key) < 0);
                    IsBinarySearchTree(root.RightChild);
                }
            }
        }
    }
}
