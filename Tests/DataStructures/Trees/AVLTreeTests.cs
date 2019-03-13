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
        }

        [TestMethod]
        public void AVLTree_Insert_Test()
        {
            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(40, "E");
            _root = _tree.Insert(_root, E);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(50, "C");
            _root = _tree.Insert(_root, C);
            HasAVLTreeProperties(_tree,_root);

            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(47, "A");
            _root = _tree.Insert(_root, A);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> G = new AVLTreeNode<int, string>(45, "G");
            _root = _tree.Insert(_root, G);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(20, "D");
            _root = _tree.Insert(_root, D);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> F = new AVLTreeNode<int, string>(35, "F");
            _root = _tree.Insert(_root, F);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(30, "B");
            _root = _tree.Insert(_root, B);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> H = new AVLTreeNode<int, string>(10, "H");
            _root = _tree.Insert(_root, H);
            HasAVLTreeProperties(_tree, _root);

            AVLTreeNode<int, string> I = new AVLTreeNode<int, string>(80, "I");
            _root = _tree.Insert(_root, I);
            HasAVLTreeProperties(_tree , _root);
        }

        [TestMethod]
        public void AVLTree_Build_Test()
        {
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
            HasAVLTreeProperties(_tree, _root);
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
            // TODO Maybe this means that you should  move this up to tree base class.
            // TODO: Most of methods such as uncle, parent, etc can go up TreeNode using T template ... 
            // TODO ANd then these tests should all move up to the TreeNode tests, given that none has to do with the properties of a binary search tree
            // TODO Also given that avl and rb are binary search tree, I would expect some more inheritence there. .. for the tree itself besides the nodes
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

        //TODO; Drop iequatable from all the tree stuff, and just use icomparable, ... 
        public void HasAVLTreeProperties<T1, T2>(AVLTree<T1, T2> tree, AVLTreeNode<T1, T2> root) where T1 : IComparable<T1>, IEquatable<T1>
        {
            BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<T1, T2>, T1, T2>(root);

            List<AVLTreeNode<T1, T2>> inOrderTraversal = new List<AVLTreeNode<T1, T2>>();
            tree.InOrderTraversal(root, inOrderTraversal);
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
