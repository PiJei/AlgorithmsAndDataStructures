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
using CSFundamentalsTests.DataStructures.Trees.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void Build()
        {
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void Delete_1()
        {
            _root = _tree.Delete(_root, 47);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_2()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_3()
        {
            _root = _tree.Delete(_root, 50);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_4()
        {
            _root = _tree.Delete(_root, 20);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_5()
        {
            _root = _tree.Delete(_root, 40);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_6()
        {
            _root = _tree.Delete(_root, 35);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_7()
        {
            _root = _tree.Delete(_root, 45);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void Delete_8()
        {
            _root = _tree.Delete(_root, 15);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void Delete_9()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 6);

            _root = _tree.Delete(_root, 47);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 5);

            _root = _tree.Delete(_root, 20);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 4);

            _root = _tree.Delete(_root, 50);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 3);

            _root = _tree.Delete(_root, 35);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 2);

            _root = _tree.Delete(_root, 45);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 1);

            _root = _tree.Delete(_root, 40);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_tree, _root, inOrderTraversal, 0);
        }

        [TestMethod]
        public void IsRed()
        {
            RedBlackTreeNode<int, string> node1 = new RedBlackTreeNode<int, string>(10, "string1");
            Assert.IsTrue(_tree.IsRed(node1));
            node1.Color = Color.Black;
            Assert.IsFalse(_tree.IsRed(node1));
        }

        [TestMethod]
        public void IsBlack()
        {
            RedBlackTreeNode<int, string> node1 = new RedBlackTreeNode<int, string>(10, "string1");
            Assert.IsFalse(_tree.IsBlack(node1));
            node1.Color = Color.Black;
            Assert.IsTrue(_tree.IsBlack(node1));
        }

        [TestMethod]
        public void UpdateParentWithNullingChild()
        {
            RedBlackTreeNode<int, string> node1 = new RedBlackTreeNode<int, string>(10, "string1");
            RedBlackTreeNode<int, string> node2 = new RedBlackTreeNode<int, string>(5, "string2");
            RedBlackTreeNode<int, string> node3 = new RedBlackTreeNode<int, string>(15, "string3");

            node1.Parent = null;
            node1.LeftChild = node2;
            node1.RightChild = node3;

            node2.Parent = node1;
            node2.LeftChild = null;
            node2.RightChild = null;

            node3.Parent = node1;
            node3.LeftChild = null;
            node3.RightChild = null;

            Assert.IsNotNull(node1.LeftChild);
            _tree.UpdateParentWithNullingChild(node1, node2);
            Assert.IsNull(node1.LeftChild);

            RedBlackTreeNode<int, string> node4 = new RedBlackTreeNode<int, string>(15, "string4");
            _tree.UpdateParentWithNullingChild(node1, node4);
            Assert.IsNull(node1.LeftChild);
            Assert.IsNotNull(node1.RightChild);
        }

        public static void HasRedBlackTreeProperties<TKey, TValue>(RedBlackTree<TKey, TValue> tree, RedBlackTreeNode<TKey, TValue> root, List<RedBlackTreeNode<TKey, TValue>> inOrderTraversal, int expectedNodeCount) where TKey : IComparable<TKey>, IEquatable<TKey>
        {
            // Check order properties.
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<RedBlackTreeNode<TKey, TValue>, TKey, TValue>(root));

            //Check to make sure nodes are not orphaned in the insertion or deletion process. 
            Assert.AreEqual(expectedNodeCount, inOrderTraversal.Count);

            // Check color properties.
            if (root != null)
                Assert.IsTrue(root.Color == Color.Black);
            foreach (RedBlackTreeNode<TKey, TValue> node in inOrderTraversal)
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
            foreach (RedBlackTreeNode<TKey, TValue> node in inOrderTraversal)
            {
                List<List<RedBlackTreeNode<TKey, TValue>>> paths = tree.GetAllPathToLeaves(node);
                int shortestPathLength = int.MaxValue;
                int longestPathLength = int.MinValue;
                int firstPathBlackNodeCount = 0;
                if (paths.Count >= 0)
                    firstPathBlackNodeCount = paths[0].Count(n => n.Color == Color.Black);
                for (int i = 1; i < paths.Count; i++)
                {
                    Assert.AreEqual(firstPathBlackNodeCount, paths[i].Count(n => n.Color == Color.Black));
                    if(paths[i].Count > longestPathLength)
                    {
                        longestPathLength = paths[i].Count;
                    }
                    if(paths[i].Count < shortestPathLength)
                    {
                        shortestPathLength = paths[i].Count;
                    }
                }

                // Ensure longest path of a node is not more than twice the shortest path. In the extreme case, shortest path might be all black nodes, and longest path would be alternating between red and black nodes
                Assert.IsTrue(longestPathLength <= 2 * shortestPathLength);
            }
        }
    }
}
