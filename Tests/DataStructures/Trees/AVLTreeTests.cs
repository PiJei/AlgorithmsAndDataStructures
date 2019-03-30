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
using CSFundamentalsTests.DataStructures.Trees.API;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class AVLTreeTests
    {
        private AVLTreeNode<int, string> _root = null;
        private AVLTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new AVLTree<int, string>();

            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>
            {
                new AVLTreeNode<int, string>(40, "E"),
                new AVLTreeNode<int, string>(50, "C"),
                new AVLTreeNode<int, string>(47, "A"),
                new AVLTreeNode<int, string>(45, "G"),
                new AVLTreeNode<int, string>(20, "D"),
                new AVLTreeNode<int, string>(35, "F"),
                new AVLTreeNode<int, string>(30, "B"),
                new AVLTreeNode<int, string>(10, "H"),
                new AVLTreeNode<int, string>(80, "I")
            };

            _root = _tree.Build(nodes);
        }

        [TestMethod]
        public void Insert()
        {
            AVLTreeNode<int, string> root = null;
            AVLTree<int, string> tree = new AVLTree<int, string>();

            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(40, "E");
            root = tree.Insert(root, E);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 1));

            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(50, "C");
            root = _tree.Insert(root, C);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 2));

            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(47, "A");
            root = tree.Insert(root, A);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 3));

            AVLTreeNode<int, string> G = new AVLTreeNode<int, string>(45, "G");
            root = tree.Insert(root, G);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 4));

            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(20, "D");
            root = tree.Insert(root, D);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 5));

            AVLTreeNode<int, string> F = new AVLTreeNode<int, string>(35, "F");
            root = tree.Insert(root, F);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 6));

            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(30, "B");
            root = tree.Insert(root, B);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 7));

            AVLTreeNode<int, string> H = new AVLTreeNode<int, string>(10, "H");
            root = tree.Insert(root, H);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 8));

            AVLTreeNode<int, string> I = new AVLTreeNode<int, string>(80, "I");
            root = tree.Insert(root, I);
            Assert.IsTrue(HasAVLTreeProperties(tree, root, 9));
        }

        [TestMethod]
        public void Build()
        {
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 9));
        }

        [TestMethod]
        public void Delete_NonExistingKey()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 25);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 9));
        }

        [TestMethod]
        public void Delete_NodeWith2Children_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 30);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWith2Children_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 40);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWith2Children_3()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 47);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 10);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 35);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren_3()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 45);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWithNoChildren_4()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 80);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWith1Children_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 20);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_NodeWith1Children_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 50);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));
        }

        [TestMethod]
        public void Delete_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 50);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));

            _root = _tree.Delete(_root, 40);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 7));

            _root = _tree.Delete(_root, 10);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 6));

            _root = _tree.Delete(_root, 80);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 5));

            _root = _tree.Delete(_root, 47);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 4));

            _root = _tree.Delete(_root, 20);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 3));

            _root = _tree.Delete(_root, 45);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 2));

            _root = _tree.Delete(_root, 30);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 1));

            _root = _tree.Delete(_root, 35);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 0));
        }

        [TestMethod]
        public void Delete_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 80);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 8));

            _root = _tree.Delete(_root, 47);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 7));

            _root = _tree.Delete(_root, 30);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 6));

            _root = _tree.Delete(_root, 35);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 5));

            _root = _tree.Delete(_root, 45);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 4));

            _root = _tree.Delete(_root, 20);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 3));

            _root = _tree.Delete(_root, 10);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 2));

            _root = _tree.Delete(_root, 50);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 1));

            _root = _tree.Delete(_root, 40);
            Assert.IsTrue(HasAVLTreeProperties(_tree, _root, 0));
        }

        [TestMethod]
        public void GetHeight()
        {
            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(50, "A");
            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(20, "B");
            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(10, "C");
            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(40, "D");
            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(30, "E");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            D.Parent = B;
            D.LeftChild = E;
            D.RightChild = null;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<int, string>, int, string>(A));
            Assert.AreEqual(4, _tree.GetHeight(A));
            Assert.AreEqual(3, _tree.GetHeight(B));
            Assert.AreEqual(1, _tree.GetHeight(C)); // Is a leaf node. 
            Assert.AreEqual(2, _tree.GetHeight(D));
            Assert.AreEqual(1, _tree.GetHeight(E)); // Is a leaf node. 
        }

        [TestMethod]
        public void GetBalanceFactor()
        {
            /* The constructed tree is not AVL, however the method GetBalanceFactor should work regardless. */
            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(50, "A");
            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(20, "B");
            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(10, "C");
            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(40, "D");
            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(30, "E");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            D.Parent = B;
            D.LeftChild = E;
            D.RightChild = null;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            Assert.AreEqual(-3, _tree.ComputeBalanceFactor(A));
            Assert.AreEqual(1, _tree.ComputeBalanceFactor(B));
            Assert.AreEqual(0, _tree.ComputeBalanceFactor(C));
            Assert.AreEqual(-1, _tree.ComputeBalanceFactor(D));
            Assert.AreEqual(0, _tree.ComputeBalanceFactor(E));
        }

        [TestMethod]
        public void Balance()
        {
            // TODO 
        }

        public bool HasAVLTreeProperties<TKey, TValue>(AVLTree<TKey, TValue> tree, AVLTreeNode<TKey, TValue> root, int expectedNodeCount) where TKey : IComparable<TKey>, IEquatable<TKey>
        {
            Assert.IsTrue(BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<TKey, TValue>, TKey, TValue>(root));
            List<AVLTreeNode<TKey, TValue>> inOrderTraversal = new List<AVLTreeNode<TKey, TValue>>();
            tree.InOrderTraversal(root, inOrderTraversal);
            Assert.AreEqual(expectedNodeCount, inOrderTraversal.Count);
            Assert.IsTrue(HasExpectedBalanceFactor(tree, inOrderTraversal));
            return true;
        }

        public bool HasExpectedBalanceFactor<TKey, TValue>(AVLTree<TKey, TValue> tree, List<AVLTreeNode<TKey, TValue>> nodes) where TKey : IComparable<TKey>, IEquatable<TKey>
        {
            foreach (AVLTreeNode<TKey, TValue> node in nodes)
            {
                int balanceFactor = tree.ComputeBalanceFactor(node);
                Assert.IsTrue(balanceFactor >= -1 && balanceFactor <= 1);
            }
            return true;
        }
    }
}
