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
using CSFundamentals.DataStructures.Trees.API;
using System;
using System.Collections.Generic;
using System.Linq;

//TODO: Add more tests with bigger trees.

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class RedBlackTreeTests
    {
        private RedBlackTree<int, string> _tree;
        private RedBlackTreeNode<int, string> _root;

        [TestInitialize]
        public void Init()
        {
            _tree = new RedBlackTree<int, string>();

            var nodes = new List<RedBlackTreeNode<int, string>>
            {
                new RedBlackTreeNode<int, string>(40, "D"),
                new RedBlackTreeNode<int, string>(50, "A"),
                new RedBlackTreeNode<int, string>(47, "G"),
                new RedBlackTreeNode<int, string>(30, "B"),
                new RedBlackTreeNode<int, string>(20, "C"),
                new RedBlackTreeNode<int, string>(35, "E"),
                new RedBlackTreeNode<int, string>(45, "F")
            };

            _root = _tree.Build(nodes);
        }

        [TestMethod]
        public void RedBlackTree_Build_Test()
        {
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_1()
        {
            _root = _tree.Delete(_root, 47);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_2()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_3()
        {
            _root = _tree.Delete(_root, 50);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_4()
        {
            _root = _tree.Delete(_root, 20);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_5()
        {
            _root = _tree.Delete(_root, 40);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_6()
        {
            _root = _tree.Delete(_root, 35);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_7()
        {
            _root = _tree.Delete(_root, 45);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_8()
        {
            _root = _tree.Delete(_root, 15);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_9()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);

            _root = _tree.Delete(_root, 47);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 5);

            _root = _tree.Delete(_root, 20);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 4);

            _root = _tree.Delete(_root, 50);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 3);

            _root = _tree.Delete(_root, 35);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 2);

            _root = _tree.Delete(_root, 45);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 1);

            _root = _tree.Delete(_root, 40);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            BinarySearchTreeBase<RedBlackTreeNode<int, string>, int, string>.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 0);
        }

        public static void HasRedBlackTreeProperties<T1, T2>(RedBlackTreeNode<T1, T2> root, List<RedBlackTreeNode<T1, T2>> inOrderTraversal, int expectedNodeCount) where T1 : IComparable<T1>, IEquatable<T1>
        {
            // Check order properties.
            BinarySearchTreeTests.HasBinarySearchTreeOrderProperty<RedBlackTreeNode<T1, T2>, T1, T2>(root);

            //Check to make sure nodes are not orphaned in the insertion or deletion process. 
            Assert.AreEqual(expectedNodeCount, inOrderTraversal.Count);

            // Check color properties.
            if (root != null)
                Assert.IsTrue(root.Color == Color.Black);
            foreach (RedBlackTreeNode<T1, T2> node in inOrderTraversal)
            {
                Assert.IsTrue(node.Color == Color.Red || node.Color == Color.Black);

                if (node.Color == Color.Red)
                {
                    if (node.LeftChild != null)
                    {
                        Assert.AreEqual(Color.Black, node.LeftChild.Color);
                    }
                    if (node.RightChild != null)
                    {
                        Assert.AreEqual(Color.Black, node.RightChild.Color);
                    }

                    /* If node N is red, then its parent must be black. As otherwise its parent is red, and the children of a red parent should all be black, in our case node N, which we assumed is red. */
                    Assert.IsTrue(node.Parent.Color == Color.Black);
                }
            }

            // all paths from a node to its null (leaf) descendants contain the same number of black nodes. 
            foreach (RedBlackTreeNode<T1, T2> node in inOrderTraversal)
            {
                List<List<RedBlackTreeNode<T1, T2>>> paths = BinarySearchTreeBase<RedBlackTreeNode<T1, T2>, T1, T2>.GetAllPathToNullLeaves(node);
                int firstPathBlackNodeCount = 0;
                if (paths.Count >= 0)
                    firstPathBlackNodeCount = paths[0].Count(n => n.Color == Color.Black);
                for (int i = 1; i < paths.Count; i++)
                {
                    Assert.AreEqual(firstPathBlackNodeCount, paths[i].Count(n => n.Color == Color.Black));
                }
            }

            // TODO 5- get the longest path, get the shortest path, assert is not more than twice.. shortest path might be all black nodes, and longest path would be alternating between red and black nodes
        }
    }
}
