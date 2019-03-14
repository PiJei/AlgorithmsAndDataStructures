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
        public void AVLTree_Insert_Test()
        {
            AVLTreeNode<int, string> root = null;
            AVLTree<int, string> tree = new AVLTree<int, string>();

            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(40, "E");
            root = tree.Insert(root, E);
            HasAVLTreeProperties(tree, root, 1);

            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(50, "C");
            root = _tree.Insert(root, C);
            HasAVLTreeProperties(tree, root, 2);

            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(47, "A");
            root = tree.Insert(root, A);
            HasAVLTreeProperties(tree, root, 3);

            AVLTreeNode<int, string> G = new AVLTreeNode<int, string>(45, "G");
            root = tree.Insert(root, G);
            HasAVLTreeProperties(tree, root, 4);

            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(20, "D");
            root = tree.Insert(root, D);
            HasAVLTreeProperties(tree, root, 5);

            AVLTreeNode<int, string> F = new AVLTreeNode<int, string>(35, "F");
            root = tree.Insert(root, F);
            HasAVLTreeProperties(tree, root, 6);

            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(30, "B");
            root = tree.Insert(root, B);
            HasAVLTreeProperties(tree, root, 7);

            AVLTreeNode<int, string> H = new AVLTreeNode<int, string>(10, "H");
            root = tree.Insert(root, H);
            HasAVLTreeProperties(tree, root, 8);

            AVLTreeNode<int, string> I = new AVLTreeNode<int, string>(80, "I");
            root = tree.Insert(root, I);
            HasAVLTreeProperties(tree, root, 9);
        }

        [TestMethod]
        public void AVLTree_Build_Test()
        {
            HasAVLTreeProperties(_tree, _root, 9);
        }


        [TestMethod]
        public void AVLTree_Delete_Test_NonExistingKey()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 25);
            HasAVLTreeProperties(_tree, _root, 9);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWith2Children_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 30);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWith2Children_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 40);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWith2Children_3()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 47);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWithNoChildren_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 10);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWithNoChildren_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 35);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWithNoChildren_3()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 45);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWithNoChildren_4()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 80);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWith1Children_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 20);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_NodeWith1Children_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 50);
            HasAVLTreeProperties(_tree, _root, 8);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_1()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 50);
            HasAVLTreeProperties(_tree, _root, 8);

            _root = _tree.Delete(_root, 40);
            HasAVLTreeProperties(_tree, _root, 7);

            _root = _tree.Delete(_root, 10);
            HasAVLTreeProperties(_tree, _root, 6);

            _root = _tree.Delete(_root, 80);
            HasAVLTreeProperties(_tree, _root, 5);

            _root = _tree.Delete(_root, 47);
            HasAVLTreeProperties(_tree, _root, 4);

            _root = _tree.Delete(_root, 20);
            HasAVLTreeProperties(_tree, _root, 3);

            _root = _tree.Delete(_root, 45);
            HasAVLTreeProperties(_tree, _root, 2);

            _root = _tree.Delete(_root, 30);
            HasAVLTreeProperties(_tree, _root, 1);

            _root = _tree.Delete(_root, 35);
            HasAVLTreeProperties(_tree, _root, 0);
        }

        [TestMethod]
        public void AVLTree_Delete_Test_2()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, nodes);
            Assert.AreEqual(9, nodes.Count);

            _root = _tree.Delete(_root, 80);
            HasAVLTreeProperties(_tree, _root, 8);

            _root = _tree.Delete(_root, 47);
            HasAVLTreeProperties(_tree, _root, 7);

            _root = _tree.Delete(_root, 30);
            HasAVLTreeProperties(_tree, _root, 6);

            _root = _tree.Delete(_root, 35);
            HasAVLTreeProperties(_tree, _root, 5);

            _root = _tree.Delete(_root, 45);
            HasAVLTreeProperties(_tree, _root, 4);

            _root = _tree.Delete(_root, 20);
            HasAVLTreeProperties(_tree, _root, 3);

            _root = _tree.Delete(_root, 10);
            HasAVLTreeProperties(_tree, _root, 2);

            _root = _tree.Delete(_root, 50);
            HasAVLTreeProperties(_tree, _root, 1);

            _root = _tree.Delete(_root, 40);
            HasAVLTreeProperties(_tree, _root, 0);
        }

        [TestMethod]
        public void AVLTree_GetHeight_Test()
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

            BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<int, string>, int, string>(A);
            Assert.AreEqual(4, _tree.GetHeight(A));
            Assert.AreEqual(3, _tree.GetHeight(B));
            Assert.AreEqual(1, _tree.GetHeight(C)); // Is a leaf node. 
            Assert.AreEqual(2, _tree.GetHeight(D));
            Assert.AreEqual(1, _tree.GetHeight(E)); // Is a leaf node. 
        }

        [TestMethod]
        public void AVLTree_GetBalanceFactor_Test()
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

        public void HasAVLTreeProperties<T1, T2>(AVLTree<T1, T2> tree, AVLTreeNode<T1, T2> root, int expectedNodeCount) where T1 : IComparable<T1>, IEquatable<T1>
        {
            BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<T1, T2>, T1, T2>(root);

            List<AVLTreeNode<T1, T2>> inOrderTraversal = new List<AVLTreeNode<T1, T2>>();
            tree.InOrderTraversal(root, inOrderTraversal);
            Assert.AreEqual(expectedNodeCount, inOrderTraversal.Count);
            HasExpectedBalanceFactor(tree, inOrderTraversal);
        }

        public void HasExpectedBalanceFactor<T1, T2>(AVLTree<T1, T2> tree, List<AVLTreeNode<T1, T2>> nodes) where T1 : IComparable<T1>, IEquatable<T1>
        {
            foreach (AVLTreeNode<T1, T2> node in nodes)
            {
                int balanceFactor = tree.ComputeBalanceFactor(node);
                Assert.IsTrue(balanceFactor >= -1 && balanceFactor <= 1);
            }
        }
    }
}
